using System.Data.Entity;
using System.Linq;
using EntittyProject.Application.Interface;
using EntittyProject.Domain.Entities;

namespace EntittyProject.Persistence.Context
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
            var entry = base.Entry(entity);

            if(entry.State == EntityState.Detached)
            {
                base.Set<TEntity>().Attach(entity);
            }

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
            base.Entry(entity).State = EntityState.Modified;
        }

        int IDb.SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
