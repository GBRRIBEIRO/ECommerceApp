using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Controllers.Admin
{
    //Sees all the admins and control roles, claims and policies
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "IsSuperAdmin")]
    public class AdminsController : ControllerBase
    {
        
        public AdminsController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Get all the non normal users
            return NotFound();
        }
    }
}
