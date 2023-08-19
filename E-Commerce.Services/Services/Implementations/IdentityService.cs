using E_Commerce.DataAcess.Repository;
using E_Commerce.DataAcess.Repository.IRepository;
using E_Commerce.Models.Models;
using E_Commerce.Models.ViewModels;
using E_Commerce.Services.Services.Configurations;
using E_Commerce.Services.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace E_Commerce.Services.Services.Implementations
{
    public class IdentityService : IIdentityService
    {
        private UserManager<ECommUser> UserManager { get; }

        public JwtOptions _jwtOptions { get; }

        private IUnitOfWork _unitOfWork;

        public SignInManager<ECommUser> SignInManager { get; }
        public IdentityService(SignInManager<ECommUser> signInManager, UserManager<ECommUser> userManager, IOptions<JwtOptions> jwtOptions, IUnitOfWork unitOfWork)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            _jwtOptions = jwtOptions.Value;
            _unitOfWork = unitOfWork;
        }


        public async Task<RegisterResponse> RegisterUser(RegisterRequest request)
        {
            var identityUser = new ECommUser 
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email,
                EmailConfirmed = true,
                PhoneNumber = request.PhoneNumber,
                PhoneNumberConfirmed = true,
            };

            //Creates and enable the user
            var result = await UserManager.CreateAsync(identityUser, request.Password);
            if (result.Succeeded)
            {
                await UserManager.SetLockoutEnabledAsync(identityUser, false);
            }

            var userResponse = new RegisterResponse(success: true);
            if (!result.Succeeded && result.Errors.Count() > 0)
            {
                userResponse.AddErrors(result.Errors.Select(err => err.Description));
            }
            return userResponse;
        }

        //Login user using email and password
        public async Task<LoginResponse> LoginUser(LoginRequest request)
        {
            //Checks if the email and password is OK
            var result = await SignInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            //If email and password is not OK, return a response with error
            if (!result.Succeeded)
            {
                var resp = new LoginResponse();
                resp.AddError("Password or Email is incorrect");
                return resp;
            }

            //Calls the function that generates the response
            return await GetUserCredentials(request.Email);

        }

        //Accepts the refresh token
        public async Task<LoginResponse> LoginWithoutPassword(string userEmail)
        {
            //Initializes the response
            var userLoginResponse = new LoginResponse();

            //Finds the user
            var user = await UserManager.FindByEmailAsync(userEmail);

            //Chain of events to add errors
            if(await UserManager.IsLockedOutAsync(user)) 
                userLoginResponse.AddError("Account Blocked!");
            else if (!await UserManager.IsEmailConfirmedAsync(user)) 
                userLoginResponse.AddError("Email not Confirmed!");

            //If login succedes return new tokens
            if (userLoginResponse.Success)
                return await GetUserCredentials(user.Email);
            
            //Else it will return the errors
            return userLoginResponse;
        }

        private string GenerateToken(IEnumerable<Claim> claims, DateTime expirationDate)
        {
            var jwt = new JwtSecurityToken
                (
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audience,
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: expirationDate,
                    signingCredentials: _jwtOptions.SigningCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }



        //Creates the response for the request
        private async Task<LoginResponse> GetUserCredentials(string email)
        {
            //Get user by email
            var user = await UserManager.FindByEmailAsync(email);


            //Obtain user claims
            var accessTokenClaims = await ObtainClaims(user, isAccessToken: true);
            //Obtain just the basic claims
            var refreshTokenClaims = await ObtainClaims(user, isAccessToken: false);


            //Sets the expiration date for both tokens
            var accessTokenExpirationDate = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
            var refreshTokenExpirationDate = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

            //Generate Tokens
            var refreshToken = GenerateToken(refreshTokenClaims, refreshTokenExpirationDate);
            var accessToken = GenerateToken(accessTokenClaims, accessTokenExpirationDate);

            //Returns the object/json with refresh token and access token
            return new LoginResponse
            (
                success: true,
                accessToken: accessToken,
                refreshToken: refreshToken
            );
        }
        //Creates and assign basic claims and roles
        private async Task<IList<Claim>> ObtainClaims(ECommUser user, bool isAccessToken)
        {
            //Create a empty list of claims
            var claims = new List<Claim>();

            //Adds all the basic JWT claims
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())); //Subject = Who refers tod
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email)); //Email
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString())); //Token ID
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString())); //Not before
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())); //Issued at

            //If it's an access token, its adds the user claims stored in the DB
            if (isAccessToken)
            {
                //Get user claims in DB
                var userClaims = await UserManager.GetClaimsAsync(user);
                //Get user roles in DB
                var roles = await UserManager.GetRolesAsync(user);

                //Add to the list of claims the user claims
                claims.AddRange(userClaims);

                //Adds the roles to a claim type of role
                foreach(var role in roles)
                {
                    claims.Add(new Claim("role", role));
                }
            }

            return claims;
        }

        public async Task<ECommUser> GetByEmail(string email)
        {   
            var user = await UserManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<List<ECommUser>> GetNonDefaultUsers()
        {
            var users = new List<ECommUser>();
            var usersFromDb = _unitOfWork.UserRoles.GetAll();
            foreach (var userFromDb in usersFromDb) 
            {
                var user = await UserManager.FindByIdAsync(userFromDb.UserId);
                if(user != null) users.Add(user);
            }
            return users;
        }
    }
}
