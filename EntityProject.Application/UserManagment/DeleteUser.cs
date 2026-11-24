using EntityProject.Application.Interface;
using EntityProject.Application.PersonManagment;

namespace EntityProject.Application.UserManagment;

public class Delete(
    IUserDataAccess userDataAccess,
    IDb db,
    IPersonDataAccess personDataAccess) : IDeleteUser
{
    void IDeleteUser.Delete(int userId)
    {
        var user = userDataAccess.GetForUpdate(userId);
        userDataAccess.Delete(user);

        var person = personDataAccess.GetForUpdate(user.PersonId);
        personDataAccess.Delete(person);

        db.SaveChanges();
    }
}