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
        Repository<Category> Category { get; set; }

        void Save();
    }
}
