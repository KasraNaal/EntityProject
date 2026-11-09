using EntittyProject.Application.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using EntityProject.Application.Interface;

namespace EntittyProject.Application.UserManagment
{
    public class UserRegisterService: IUserRegisterService
    {
        private readonly IUserValidation _userValidation;
        private readonly IUserDataAccess _userDataAccess;
        private readonly IDb _db;

        public UserRegisterService(IUserValidation userValidation, IUserDataAccess userDataAccess, IDb db)
        {
            _userValidation = userValidation;
            _userDataAccess = userDataAccess;
            _db = db;
        }

        public string RegisterUser(UserRegisterRequest user)
        {
            var validationResult = _userValidation.PasswordValidation(user.Password);
            if (validationResult != "Password confirmed")
            {
                return validationResult;
            }

            var newUser = new EntityProject.Domain.Entities.User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password
            };
           
            _userDataAccess.AddUser(newUser);
            _db.SaveChanges();

            return "User registered successfully";
        }
    }
}