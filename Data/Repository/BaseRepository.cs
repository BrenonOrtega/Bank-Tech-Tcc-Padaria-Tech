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

        public virtual Task<T> GetById(int id)
        {
           return Get(x => x.Id == id).OfType<T>().FirstOrDefaultAsync();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async void Update<V>(int id, T entity, V updatedData)
        {
            var result = await _dbSet.FirstOrDefaultAsync(e => e.Id.Equals(id));

            if (result is not null)
            {
                _context.Entry(result).CurrentValues.SetValues(updatedData);
            }
        }

    }
}
