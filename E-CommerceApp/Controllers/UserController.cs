using E_Commerce.Models.Models;
using E_Commerce.Models.ViewModels;
using E_Commerce.Services.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace E_CommerceApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public IIdentityService _identityService { get; }

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> LoginPost([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _identityService.LoginUser(loginRequest);
            if (result.Success) return Ok(result);
            else return Unauthorized(result);

        }

        [Authorize]
        [Route("refresh-login")]
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> LoginWithRefreshToken()
        {
            //If user is using a token, it gets the token
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            //Finds the claims that is the name identifier
            var userEmail = identity?.FindFirst(ClaimTypes.Email)?.Value;

            if (userEmail == null) return BadRequest();

            var result = await _identityService.LoginWithoutPassword(userEmail);
            if (result.Success)
                return Ok(result);

            return Unauthorized(result);
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<RegisterResponse>> RegisterPost([FromBody] RegisterRequest registerRequest)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _identityService.RegisterUser(registerRequest);
            if(result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [Route("email")]
        [HttpPost]
        public async Task<ActionResult<ECommUser>> GetUserByEmail([FromBody] string email)
        {
            var user = await _identityService.GetByEmail(email);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [Route("employees")]
        [HttpPost]
        public async Task<ActionResult<List<ECommUser>>> GetEmployees()
        {
            var users = await _identityService.GetNonDefaultUsers();
            if (users == null) return NotFound();
            return Ok(users);
        }
    }
}
