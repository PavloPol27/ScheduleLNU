using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ScheduleLNU.DataAccess.Repository
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        void Add(TEntity entity);


        void Update(TEntity entity);


        void Delete(TEntity entity);


        TEntity Select(Expression<Func<TEntity, bool>> selector);
        

        IEnumerable<TEntity> Select();


        IEnumerable<TEntity> SelectAll(Expression<Func<TEntity, bool>> selector);
    }
}
