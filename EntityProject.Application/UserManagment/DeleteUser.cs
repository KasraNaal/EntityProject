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
        if (userId <= 0)
            throw new AppException("Invalid userId!");


        var user = userDataAccess.GetForUpdate(userId);

        if (user is null)
            throw new AppException("User not found!");

        userDataAccess.Delete(user);

        var person = personDataAccess.GetForUpdate(user.PersonId);

        if (person is null)
            throw new AppException("Person not found!");

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