using E_Commerce.DataAcess.Repository.IRepository;
using E_Commerce.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Controllers.Admin
{
    //Sees all the admins and control roles, claims and policies
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "SuperAdmin")]
    public class RolesController : ControllerBase
    {
        private RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ECommUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ECommUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IdentityRole>> GetAll()
        {
            var roles = _roleManager.Roles.ToList();
            if (roles == null) 
                return NotFound();
            return Ok(roles);
        }

        [HttpPost]
        [Route("assign-user")]
        public async Task<ActionResult> AssignUser([FromBody] string roleId, Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var role = await _roleManager.FindByIdAsync(roleId);
            var result = _userManager.AddToRoleAsync(user, role.Name);

            return Ok();
        }
    }
}
