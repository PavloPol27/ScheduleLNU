using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScheduleLNU.DataAccess.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> selector);

        Task<IEnumerable<TEntity>> SelectAllAsync();

        Task<IEnumerable<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> selector);

        Task<IEnumerable<TEntity>> SelectAllWithIncludeAsync(
            Expression<Func<TEntity, bool>> selector,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> SelectAllWithIncludeAsync(
           params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
