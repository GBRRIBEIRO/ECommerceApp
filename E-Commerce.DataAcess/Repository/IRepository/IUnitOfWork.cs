using E_Commerce.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAcess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public Repository<Category> Categories { get; set; }
        public Repository<Product> Products { get; set; }
        public Repository<Rating> Ratings { get; set; }
        public Repository<Address> Addresses { get; set; }


        void Save();
    }
}
