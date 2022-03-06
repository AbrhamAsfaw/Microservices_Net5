using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microservices.Common;

namespace Microservices.Common
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T , bool>> filter);

        Task<T> GetAsync(Guid id);
        Task<T> GetAsync(Expression<Func<T , bool>> filter);
        Task UpdateAsync(T entity);
    }
}