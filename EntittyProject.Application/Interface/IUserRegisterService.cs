using EntittyProject.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyProject.Application.Interface
{
    public interface IUserRegisterService
    {
        string RegisterUser(UserRegisterDto user);
    }
}
