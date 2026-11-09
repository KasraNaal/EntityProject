using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyProject.Application.UserManagment
{
    public interface IUserRegisterService
    {
        string RegisterUser(UserRegisterRequest user);
    }
}
