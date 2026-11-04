using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProject.Domain.Entities;

namespace EntittyProject.Application.Interface
{
    public interface IDataAccess
    {
        void AddUser(User user);
        List<User> Load();
        void UpdateUser(User user);
        void DeleteUser(int Id);
    }
}
