using E_Commerce.DataAcess.Data;
using E_Commerce.DataAcess.Repository.IRepository;
using E_Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Models.Models;

namespace E_Commerce.DataAcess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public Repository<Category> Category { get; set; }

        private ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Category = new Repository<Category>(dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
