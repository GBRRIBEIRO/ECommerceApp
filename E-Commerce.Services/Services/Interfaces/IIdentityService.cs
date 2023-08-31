using E_Commerce.Models.Models;
using E_Commerce.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<RegisterResponse> RegisterUser(RegisterRequest request);
        Task<LoginResponse> LoginUser(LoginRequest request);
        Task<LoginResponse> LoginWithoutPassword(string userEmail);
        Task<ECommUser> GetByEmail(string email);
        Task<List<ECommUser>> GetNonDefaultUsers();
    }
}
