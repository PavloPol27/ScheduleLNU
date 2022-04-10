using System;
using System.Collections.Generic;

<<<<<<< HEAD:Domain/Repository/IRepository.cs
namespace Domain.Repository
=======
namespace DataAccess.Repository
>>>>>>> create_layered_architecture:ScheduleLNU.DataAccess/Repository/IRepository.cs
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        void Add(TEntity entity);


        void Update(TEntity entity);


        void Delete(TEntity entity);


        TEntity Select(Func<TEntity, bool> selector);
        

        IEnumerable<TEntity> Select();


        IEnumerable<TEntity> SelectAll(Func<TEntity, bool> selector);
    }
}
