using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityProject.Domain.Entities;
using EntittyProject.Domain.Interfaces;



namespace EntityProject.Application.Interface
{
    public interface IDb: IDisposable
    {
        DbSet<User> Users { get; set; }

        IQueryable<TEntity> Query<TEntity>() where TEntity: class, IEntity;
        IQueryable<TEntity> Set<TEntity>() where TEntity: class, IEntity;

        TEntity Add<TEntity>(TEntity entity) where TEntity: class, IEntity;
        void Delete<TEntity>(TEntity entity) where TEntity: class, IEntity;
        void DeleteById<TEntity>(int id) where TEntity : class, IEntity;
        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;

        int SaveChanges();
    }
}