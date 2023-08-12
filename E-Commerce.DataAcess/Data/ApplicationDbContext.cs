using E_Commerce.DataAcess.Repository;
using E_Commerce.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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


    }
}
