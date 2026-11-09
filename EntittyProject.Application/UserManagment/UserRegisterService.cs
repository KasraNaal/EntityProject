using EntittyProject.Application.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProject.Application.Interface;
using EntittyProject.Application.DTO;

namespace EntittyProject.Application.UseCase
{
    public class UserRegisterService
    {
        private readonly IUserValidation _userValidation;
        private readonly IUserDataAccess _userDataAccess;

        public UserRegisterService(IUserValidation userValidation, IUserDataAccess userDataAccess)
        {
            _userValidation = userValidation;
            _userDataAccess = userDataAccess;
        }

        public string RegisterUser(UserRegisterDto user)
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
            return "User registered successfully";
        }
    }
}