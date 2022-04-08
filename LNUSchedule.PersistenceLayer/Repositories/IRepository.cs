using LNUSchedule.PersistenceLayer.Models;

namespace LNUSchedule.PersistenceLayer.Repositories
{
    public interface IRepository<TEntity>  where TEntity : IEntity
    {
        void Add(TEntity entity);


        void Update(TEntity entity);


        void Delete(TEntity entity);


        TEntity Select(Predicate<TEntity> selector);
        

        IEnumerable<TEntity> GetAll();


        IEnumerable<TEntity> SelectAll(Predicate<TEntity> selector);
    }
}
