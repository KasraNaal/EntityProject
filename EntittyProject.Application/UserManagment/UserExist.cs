using EntittyProject.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntittyProject.Application.UserManagment
{
    public class UserExist(IUserDataAccess userDataAccess) : IUserExist
    {
        public bool IUserExist(string UserName)
        {
            return userDataAccess.DoesUserExist(UserName);
        }
    }
}
