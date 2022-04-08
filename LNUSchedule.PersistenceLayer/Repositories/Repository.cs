using Microsoft.EntityFrameworkCore;

namespace LNUSchedule.PersistenceLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dataBaseContext;

        
        private readonly DbSet<TEntity> _entities;
        

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
            _dataBaseContext.SaveChanges();
        }


        public void Update(TEntity entity)
        {
            _dataBaseContext.Entry(entity).State = EntityState.Modified;
            _dataBaseContext.SaveChanges();
        }


        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
            _dataBaseContext.SaveChanges();
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _entities.AsNoTracking().ToList();
        }


        public TEntity? Select(Func<TEntity, bool> selector)
        {
            return _entities.FirstOrDefault(selector);
        }


        public IEnumerable<TEntity> SelectAll(Func<TEntity, bool> selector)
        {
            return _entities.AsNoTracking().Where(selector);
        }


        public Repository(DbContext context)
        {
            _dataBaseContext = context;
            _entities = context.Set<TEntity>();
        }
    }
}
