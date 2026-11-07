using EntittyProject.Application.DTO;
using EntittyProject.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyProject.Application.UseCase
{
    public class UserValidation: IUserValidation
    {
        public string PasswordValidation(UserRegisterDto user)
        {
            if (!(user.Password.Count() >= 8) || !(user.Password.Contains('@')))
            {
                return "Your password should be more than 8 characters and contains @";
            }
            return"Password confirmed";
        }
    }
}
