using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetDeletedAll(Expression<Func<T, bool>> filter = null);
        Task<T?> Get(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task Delete(T entity);
        Task Terminate(T entity);

    }
}
