using EntityProject.Application.Exceptions;
using EntityProject.Application.Extensions;
using EntityProject.Application.Interface;
using EntityProject.Application.PersonManagment;
using System;

namespace EntityProject.Application.UserManagment;

public class Delete(
    IUserDataAccess userDataAccess,
    IDb db,
    IPersonDataAccess personDataAccess) : IDeleteUser
{
    void IDeleteUser.Delete(int userId)
    {
        userId.IsUserIdValidate("userId");


        var user = userDataAccess.GetForUpdate(userId).IsObjectFound("User");
        userDataAccess.Delete(user);

        var person = personDataAccess.GetForUpdate(user.PersonId).IsObjectFound("Person");
        personDataAccess.Delete(person);

        try
        {
            db.SaveChanges();
        }
        catch(Exception ex)
        {
            throw new AppException("An unexpected error occurred from the database!", ex);
        }
    }
}