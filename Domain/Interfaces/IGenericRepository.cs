using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PadariaTech.Domain.Interfaces
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);

        void Delete(T entity);

        void Update(int id, T entity);

        IQueryable<T> Get(Expression<Func<T, bool>> expression);

        Task<int> SaveChanges();
    }
}