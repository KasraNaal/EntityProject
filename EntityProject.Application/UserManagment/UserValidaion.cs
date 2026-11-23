using System.Linq;

namespace EntityProject.Application.UserManagment
{
    public class UserValidation: IUserValidation
    {
        public string PasswordValidation(string password)
        {
            if (!(password.Count() >= 8) || !(password.Contains('@')))
            {
                return "Your password should be more than 8 characters and contains @";
            }
            return"Password confirmed";
        }
    }
}
