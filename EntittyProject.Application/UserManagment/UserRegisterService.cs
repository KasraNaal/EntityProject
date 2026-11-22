using EntittyProject.Application.Interface;
using EntittyProject.Domain.Entities;
using System;
using System.Linq;

namespace EntittyProject.Application.UserManagment
{
    public class UserRegisterService(IUserValidation userValidation, IUserDataAccess userDataAccess, IDb db, IUserExist userExist) : IUserRegisterService
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

            if (userExist.IsUserExist(user.UserName))
            {
                return "User already exists";
            }

            userDataAccess.AddUser(newUser);
            db.SaveChanges();

            return "User registered successfully";
        }

        //private bool IsUserExist(string userName)
        //{
        //    return searchUsers.Respond(new ISearchUsers.Request
        //    {
        //        Keyword = userName
        //    }).Any();
        //}
    }
}