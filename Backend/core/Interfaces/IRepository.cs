using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression < Func < T, bool >> expression);
        Task AddAsync(T entity);
        void RemoveAsync(T entity);
        void UpdateAsync(T entity);

        Task<bool> isExitAsync(Expression<Func<T, bool>> expression);
    }
}