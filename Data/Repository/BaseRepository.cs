using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PadariaTech.Domain.Models;
using PadariaTech.Domain.Interfaces;

namespace PadariaTech.Data.Repository
{
    public abstract class BaseRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly DbContext _context;

        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            var query = _dbSet.Where(expression);

            return query;
        }

        public virtual T GetById(int id)
        {
           return Get(x => x.Id == id).OfType<T>().FirstOrDefault();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }


        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(int id, T entity)
        {
            var result = _dbSet.FirstOrDefault(e => e.Id.Equals(id));

            if (result is not null)
            {
                _context.Entry(result).CurrentValues.SetValues(entity);
            }
        }

    }
}
