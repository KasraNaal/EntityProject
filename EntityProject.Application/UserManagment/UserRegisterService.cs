using EntityProject.Application.Exceptions;
using EntityProject.Application.Interface;
using EntityProject.Domain.Entities;

namespace EntityProject.Application.UserManagment;

public class UserRegisterService(IUserValidation userValidation, IUserDataAccess userDataAccess, IDb db, IIsUserExist userExist) : IUserRegisterService
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
            throw new AppException("User already exist!");

        userDataAccess.Add(newUser);
        db.SaveChanges();

        return "User registered successfully";
    }
}