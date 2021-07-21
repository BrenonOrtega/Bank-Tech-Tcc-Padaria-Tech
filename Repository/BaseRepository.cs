using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PadariaTech.Models.Base;
using PadariaTech.Interfaces;

namespace PadariaTech.Repository
{
    public abstract class BaseRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        private readonly DbContext _context;

        private readonly DbSet<T> _dbSet;
        
        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(int id, T entity)
        {
            var result = _dbSet.FirstOrDefault(e => e.Id.Equals(id));

            if(result is not null)
            {
                _context.Entry(result).CurrentValues.SetValues(entity);
            }
        }
    }
}
