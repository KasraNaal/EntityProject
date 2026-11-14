using EntittyProject.Domain.Interfaces;
using EntityProject.Application.Interface;
using EntityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using EntittyProject.Application;

namespace EntityProject.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDb
    {
        public DataBaseContext() : base("name=DataBaseContext")
        {
            Database.SetInitializer<DataBaseContext>(null);
        }

        public DbSet<User> Users { get; set; }


        TEntity IDb.Add<TEntity>(TEntity entity)
        {
            return base.Set<TEntity>().Add(entity);
        }

        void IDb.Delete<TEntity>(TEntity entity)
        {
            base.Set<TEntity>().Attach(entity);
            base.Set<TEntity>().Remove(entity);
        }

        void IDb.DeleteById<TEntity>(int id)
        {
            var entity = base.Set<TEntity>().Create();
            entity.Id = id;

            base.Set<TEntity>().Attach(entity);
            base.Set<TEntity>().Remove(entity);
        }

        IQueryable<TEntity> IDb.Query<TEntity>()
        {
            return base.Set<TEntity>().AsNoTracking();
        }

        IQueryable<TEntity> IDb.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        void IDb.Update<TEntity>(TEntity entity)
        {
            base.Set<TEntity>().Attach(entity);
            base.Entry(entity).State = EntityState.Modified;
        }

        int IDb.SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
