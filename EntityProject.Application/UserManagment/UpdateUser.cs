using EntityProject.Application.Interface;
using EntityProject.Application.PersonManagment;
using static EntityProject.Application.UserManagment.IUpdateUser;

namespace EntityProject.Application.UserManagment;

public class UpdateUser(IUserDataAccess userDataAccess, IDb db, IPersonDataAccess personDataAccess) : IUpdateUser
{
    void IUpdateUser.Update(UpdateRequest updateRequest)
    {
        var user = userDataAccess.GetForUpdate(updateRequest.Id);

        if(user == null)
        {
            throw new System.Exception("User not found!");
        }
        user.UserName = updateRequest.UserName;
        user.Password = updateRequest.Password;
        
        var person = personDataAccess.GetForUpdate(user.PersonId);

        if(person == null)
        {
            throw new System.Exception("Person not foun!");
        }

        person.FirstName = updateRequest.FirstName;
        person.LastName = updateRequest.LastName;
        
        db.SaveChanges();
    }
}
