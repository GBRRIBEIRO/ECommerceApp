using E_Commerce.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ECommUser> _userManager;
        private readonly SignInManager<ECommUser> _signInManager;

        public UserController(UserManager<ECommUser> userManager, SignInManager<ECommUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string emailFilter) 
        {
            var result = _userManager.FindByEmailAsync(emailFilter);
            if(result == null) return NotFound("User not found!");
            return Ok(result);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginPost([FromQuery] string emailFilter)
        {
            var result = _userManager.FindByEmailAsync(emailFilter);
            if (result == null) return NotFound("User not found!");
            return Ok(result);
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> RegisterPost([FromQuery] string emailFilter)
        {
            var result = _userManager.FindByEmailAsync(emailFilter);
            if (result == null) return NotFound("User not found!");
            return Ok(result);
        }


          
        
    }
}
