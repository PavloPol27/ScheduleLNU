using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ScheduleLNU.DataAccess.Repository
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        void Insert(TEntity entity);


        void Update(TEntity entity);


        void Delete(TEntity entity);


        TEntity Select(Expression<Func<TEntity, bool>> selector);
        

        IEnumerable<TEntity> SelectAll();


        IEnumerable<TEntity> SelectAll(Expression<Func<TEntity, bool>> selector);


        IEnumerable<TEntity> SelectAllWithInclude(
            Expression<Func<TEntity, bool>> selector,
            params Expression<Func<TEntity, object>>[] includeProperties);


        IEnumerable<TEntity> SelectAllWithInclude(
           params Expression<Func<TEntity, object>>[] includeProperties);

    }
}
