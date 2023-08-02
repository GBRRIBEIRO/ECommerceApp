using E_Commerce.DataAcess.Data;
using E_Commerce.DataAcess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAcess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbSet<T> _dbSet;
        private ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                query.Where(filter);
                return query.FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
            
            
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
        }

        public void Patch(T obj)
        {
            _dbSet.Update(obj);
        }

        public void Post(T obj)
        {
            _dbSet.Add(obj);
        }
    }
}
