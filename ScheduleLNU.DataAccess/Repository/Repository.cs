using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ScheduleLNU.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dataBaseContext;

        
        private readonly DbSet<TEntity> _entitiesDataSet;
        

        private IQueryable<TEntity> GetValueWithInclude(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> querriedEntities = _entitiesDataSet.AsNoTracking();
            return includeProperties
                .Aggregate(querriedEntities, (current, includeProperty) 
                => current.Include(includeProperty));
        }


        public void Add(TEntity entity)
        {
            _entitiesDataSet.Add(entity);
            _dataBaseContext.SaveChanges();
        }


        public void Update(TEntity entity)
        {
            _dataBaseContext.Attach(entity).State = EntityState.Modified;
            _dataBaseContext.SaveChanges();
        }


        public void Delete(TEntity entity)
        {
            _entitiesDataSet.Remove(entity);
            _dataBaseContext.SaveChanges();
        }


        public IEnumerable<TEntity> Select()
        {
            return _entitiesDataSet.AsNoTracking().ToList();
        }


        public TEntity Select(Expression<Func<TEntity, bool>> selector)
        {
            return _entitiesDataSet.FirstOrDefault(selector);
        }


        public IEnumerable<TEntity> SelectAll(Expression<Func<TEntity, bool>> selector)
        {
            return _entitiesDataSet.AsNoTracking().Where(selector);
        }


        public IEnumerable<TEntity> SelectWithInclude(
            Func<TEntity, bool> selector,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetValueWithInclude(includeProperties).Where(selector).ToList();
        }


        public IEnumerable<TEntity> SelectAllWithInclude(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetValueWithInclude(includeProperties).ToList();
        }


        public Repository(DbContext context)
        {
            _dataBaseContext = context;
            _entitiesDataSet = context.Set<TEntity>();
        }
    }
}
