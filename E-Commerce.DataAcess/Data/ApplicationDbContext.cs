using E_Commerce.DataAcess.Repository;
using E_Commerce.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using E_Commerce.Models.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNet.Identity;

namespace E_Commerce.DataAcess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ECommUser>
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ImageStorage> Images { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var hasher = new PasswordHasher<ECommUser>();
            var hashed = hasher.HashPassword(new ECommUser(),"49100216-b0a0-45ca-9bc9-6b0946f7e789");

            var nUser = new ECommUser("admin", "admin", "admin@admin.com", hashed, "9999999");
            builder.Entity<ECommUser>().HasData(nUser);
            
        }

    }
}