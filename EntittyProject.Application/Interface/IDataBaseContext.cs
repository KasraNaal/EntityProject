using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityProject.Domain.Entities;

namespace EntityProject.Application.Interface
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}