using EntityProject.Application.Interface;
using EntityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDb
    {
        public DataBaseContext() : base("name=DataBaseContext")
        {
            Database.SetInitializer<DataBaseContext>(null);
        }

        public DbSet<User> Users { get; set; }
    }
}
