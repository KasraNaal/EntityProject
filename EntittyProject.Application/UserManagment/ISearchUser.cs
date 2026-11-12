using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProject.Domain.Entities;

namespace EntittyProject.Application.UserManagment
{
    public interface ISearchUser
    {
        List<User> Search(string userSearch);
    }
}
