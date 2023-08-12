using E_Commerce.Models.Models;
using E_Commerce.Models.Models.ViewModels;
using E_Commerce.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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


        //[Authorize(Policy = "Admin")]
        //[HttpGet]
        //public async Task<IActionResult> GetUserByEmail([FromQuery] string emailFilter) 
        //{
        //    var result = _userManager.FindByEmailAsync(emailFilter);
        //    if(result == null) return NotFound("User not found!");
        //    return Ok(result);
        //}

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> LoginPost([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _identityService.LoginUser(loginRequest);
            if (result.Success) return Ok(result);
            else return Unauthorized(result);

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
    }
}
