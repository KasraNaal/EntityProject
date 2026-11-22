using EntittyProject.Domain.Interfaces;
using System;
using System.Linq;

namespace EntittyProject.Application.Interface
{
    public interface IDb : IDisposable
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;
        IQueryable<TEntity> Set<TEntity>() where TEntity : class, IEntity;

        TEntity Add<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void DeleteById<TEntity>(int id) where TEntity : class, IEntity;
        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;

        int SaveChanges();
    }
}