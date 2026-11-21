using EntittyProject.Application.Interface;
using EntittyProject.Domain.Entities;

namespace EntittyProject.Application.UserManagment
{
    public class UserRegisterService(IUserValidation userValidation, IUserDataAccess userDataAccess, IDb db) : IUserRegisterService
    {
        public string RegisterUser(UserRegisterRequest user)
        {
            var validationResult = userValidation.PasswordValidation(user.Password);
            if (validationResult != "Password confirmed")
            {
                return validationResult;
            }

            var newPerson = new Person
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            var newUser = new User
            {
                UserName = user.UserName,
                Password = user.Password,
                Person = newPerson
            };

            if (userDataAccess.DoesUserExist(user.UserName))
            {
                return "User already exists";
            }

            userDataAccess.AddUser(newUser);
            db.SaveChanges();

            return "User registered successfully";
        }
    }
}