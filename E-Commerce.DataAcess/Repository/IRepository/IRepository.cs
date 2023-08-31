using E_Commerce;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAcess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        
        public IEnumerable<T> GetAll();
        public T Get(Expression<Func<T, bool>> filter);
        public void Post(T obj);
        public void Patch(T obj);
        public void Delete(T obj);
    }
}
