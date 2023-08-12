using E_Commerce.Models.Models;
using E_Commerce.Models.Models.ViewModels;
using E_Commerce.Services.Services.Configurations;
using E_Commerce.Services.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Services.Implementations
{
    public class IdentityService : IIdentityService
    {
        private UserManager<ECommUser> UserManager { get; }

        public JwtOptions _jwtOptions { get; }

        public SignInManager<ECommUser> SignInManager { get; }
        public IdentityService(SignInManager<ECommUser> signInManager, UserManager<ECommUser> userManager, IOptions<JwtOptions> jwtOptions)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            _jwtOptions = jwtOptions.Value;
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
        public async Task<LoginResponse> LoginUser(LoginRequest request)
        {
            var result = await SignInManager.PasswordSignInAsync(request.Email, request.Password, false, true);
            if (result.Succeeded)
            {
                return await GenerateToken(request.Email);
            }
            var userResponse = new LoginResponse(result.Succeeded);
            if (!result.Succeeded)
            {
                //if(result.IsLockedOut)
                //{
                //    userResponse.AddErrors("Essa conta está bloqueada!");
                //}
            }
            return userResponse;
        }

        private async Task<LoginResponse> GenerateToken(string email, bool isRefreshToken = false)
        {

            
            var user = await UserManager.FindByEmailAsync(email);

            if (isRefreshToken)
            {
                
            }


            var tokenClaims = await ObtainClaims(user);
            var _expirationDate = DateTime.Now.AddSeconds(_jwtOptions.Expiration);

            var jwt = new JwtSecurityToken(
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audience,
                    claims: tokenClaims,
                    notBefore: DateTime.Now,
                    expires: _expirationDate,
                    signingCredentials: _jwtOptions.SigningCredentials
                );
            var _token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new LoginResponse(
                success: true,
                token: _token,
                expirationDate: _expirationDate
                );

        }

        private async Task<IList<Claim>> ObtainClaims(ECommUser user)
        {
            var claims = await UserManager.GetClaimsAsync(user);
            var roles = await UserManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));
            foreach(var role in roles)
            {
                claims.Add(new Claim("role", role));
            }
            return claims;
        }
    }
}
