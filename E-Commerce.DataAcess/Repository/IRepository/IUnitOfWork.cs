using E_Commerce.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.DataAcess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public Repository<Category> Categories { get; set; }
        public Repository<Product> Products { get; set; }
        public Repository<Rating> Ratings { get; set; }
        public Repository<Address> Addresses { get; set; }
        public Repository<IdentityUserRole<string>> UserRoles { get; set; }

        void Save();
    }
}
