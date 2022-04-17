using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScheduleLNU.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext dataBaseContext;

        private readonly DbSet<TEntity> entitiesDataSet;

        public Repository(DbContext context)
        {
            this.dataBaseContext = context;
            this.entitiesDataSet = context.Set<TEntity>();
        }

        public async Task InsertAsync(TEntity entity)
        {
            this.entitiesDataSet.Add(entity);
            await this.dataBaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this.dataBaseContext.Attach(entity).State = EntityState.Modified;
            await this.dataBaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            this.entitiesDataSet.Remove(entity);
            await this.dataBaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> SelectAllAsync()
        {
            return await this.entitiesDataSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> selector)
        {
            return await this.entitiesDataSet.FirstOrDefaultAsync(selector);
        }

        public async Task<IEnumerable<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> selector)
        {
            return await this.entitiesDataSet.AsNoTracking().Where(selector).ToListAsync();
        }

        // add to interfacre
        public async Task<IEnumerable<TEntity>> SelectAllWithIncludeAsync(
            Expression<Func<TEntity, bool>> selector,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await this.GetValueWithInclude(includeProperties).Where(selector).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> SelectAllWithIncludeAsync(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await this.GetValueWithInclude(includeProperties).ToListAsync();
        }

        private IQueryable<TEntity> GetValueWithInclude(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> querriedEntities = this.entitiesDataSet.AsNoTracking();

            return includeProperties.Aggregate(querriedEntities, (current, includeProperty)
                => current.Include(includeProperty));
        }
    }
}
