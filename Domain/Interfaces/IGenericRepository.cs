using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PadariaTech.Domain.Models;

namespace PadariaTech.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        void Add(T entity);

        void Delete(int id);

        void Update<V>(int id, T entity, V updatedData);

        IQueryable<T> Get(Expression<Func<T, bool>> expression);

        Task<T> GetById(int id);

        Task<int> SaveChangesAsync();
    }
}