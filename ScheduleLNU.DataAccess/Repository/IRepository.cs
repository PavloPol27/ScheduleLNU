﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.DataAccess.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> selector);

        Task<TEntity> SelectWithIncludeAsync(Expression<Func<TEntity, bool>> selector,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> SelectAllAsync();

        Task<IEnumerable<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> selector);

        Task<IEnumerable<TEntity>> SelectAllWithIncludeAsync(
           params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> SelectAllByIdAsync(int id);

        Task<IEnumerable<TEntity>> SelectAllWithIncludeAsync(
            Expression<Func<TEntity, bool>> selector,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> SelectAllByIdWithIncludeAsync(int id,
            params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
