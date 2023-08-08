using E_Commerce.DataAcess.Repository;
using E_Commerce.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAcess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ECommUser>
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


    }
}
