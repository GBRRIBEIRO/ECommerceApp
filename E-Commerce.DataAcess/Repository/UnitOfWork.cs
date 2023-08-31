using E_Commerce.DataAcess.Repository.IRepository;
using E_Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Models.Models;
using System.Security.Claims;
using E_Commerce.DataAcess.Data;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.DataAcess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public Repository<Category> Categories { get; set; }
        public Repository<Product> Products { get; set; }
        public Repository<Rating> Ratings { get; set; }
        public Repository<Address> Addresses { get; set; }
        public Repository<ImageStorage> Images { get; set; }
        public Repository<IdentityUserRole<string>> UserRoles { get; set; }

        private ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Categories = new Repository<Category>(dbContext);
            Products = new Repository<Product>(dbContext);
            Ratings = new Repository<Rating>(dbContext);
            Addresses = new Repository<Address>(dbContext); 
            Images = new Repository<ImageStorage>(dbContext);
            UserRoles = new Repository<IdentityUserRole<string>>(dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
