using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyProject.Application.UseCase
{
    public class UserValidation
    {
        public string PasswordValidation(string password)
        {
            if (password.Count() > 8 || password.Contains('@'))
            {
                return password;
            }
            return "Your password should be more than 8 character and contains '@'";
        }
    }
}
