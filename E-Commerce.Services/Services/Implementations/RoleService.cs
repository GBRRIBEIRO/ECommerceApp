
using E_Commerce.DataAcess.Repository.IRepository;
using E_Commerce.Models.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace E_Commerce.Services.Services.Implementations
{
    public class RoleService
    {
        private UserManager<ECommUser> _userManager { get; }
        private RoleManager<IdentityRole> _roleManager { get; }
        private IUnitOfWork _unitOfWork { get; }

        public RoleService(UserManager<ECommUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void AddAdmin(ECommUser user)
        {
            //var roles = await _userManager.GetRolesAsync();
            //new IdentityRole("Admin")
        }


        public async Task<bool> AddRole(string roleName, List<Claim> claims)
        {
            var role = new IdentityRole(roleName);
            var result = await _roleManager.CreateAsync(role);
            if(!result.Succeeded)
            {
                return false;
            }
            return true;

        }

        public void AssignClaimToRole(IdentityRole role, Claim claim)
        {
         
            
        }
        public List<IdentityRole>? GetRoles() 
        {
            var roles = _roleManager.Roles.ToList();
            if (!roles.IsNullOrEmpty()) return roles;

            return new List<IdentityRole>();
        }
    }
}
