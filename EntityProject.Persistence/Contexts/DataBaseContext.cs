using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Persistence.Contexts
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext(): base("name=DataBaseContext")
        {
            
        }

        protected DbSet<User> Users { get; set; }
    }
}
