using EntityProject.Application.Exceptions;
using EntityProject.Application.Extensions;
using EntityProject.Application.Interface;
using EntityProject.Application.PersonManagment;
using System;
using static EntityProject.Application.UserManagment.IUpdateUser;

namespace EntityProject.Application.UserManagment;

public class UpdateUser(IUserDataAccess userDataAccess, IDb db, IPersonDataAccess personDataAccess) : IUpdateUser
{
    void IUpdateUser.Update(UpdateRequest updateRequest)
    {
        var user = userDataAccess.GetForUpdate(updateRequest.Id);

        user.IsObjectFound("User");
        user.UserName = updateRequest.UserName;
        user.Password = updateRequest.Password;
        
        var person = personDataAccess.GetForUpdate(user.PersonId);

        person.IsObjectFound("Person");
        person.FirstName = updateRequest.FirstName;
        person.LastName = updateRequest.LastName;
        
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
