using EntittyProject.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntittyProject.Application.UserManagment
{
    public class UserExist : IUserExist
    {
        private readonly IUserDataAccess _userDataAccess;

        public UserExist(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public bool IUserExist(string UserName)
        {
            return _userDataAccess.DoesUserExist(UserName);
        }
    }
}
