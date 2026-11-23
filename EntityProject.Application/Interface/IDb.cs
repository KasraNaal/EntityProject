using System;
using System.Linq;
using EntityProject.Domain.Interfaces;

namespace EntityProject.Application.Interface
{
    public interface IDb : IDisposable
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;
        IQueryable<TEntity> Set<TEntity>() where TEntity : class, IEntity;

        TEntity Add<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;
        int SaveChanges();
    }
}