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

        void Delete(T entity);

        void Update(int id, T entity);

        IQueryable<T> Get(Expression<Func<T, bool>> expression);

        T GetById(int id);

        Task<int> SaveChanges();
    }
}