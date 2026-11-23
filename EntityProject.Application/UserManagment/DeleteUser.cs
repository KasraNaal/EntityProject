using EntityProject.Application.Interface;
using EntityProject.Application.PersonManagment;

namespace EntityProject.Application.UserManagment
{
    public class DeleteUser(
        IUserDataAccess userDataAccess,
        IDb db,
        IPersonDataAccess personDataAccess) : IDeleteUser
    {
        void IDeleteUser.DeleteUser(int userId, int personId)
        {
            var user = userDataAccess.GetForUpdate(userId);
            userDataAccess.Delete(user);

            var person = personDataAccess.GetForUpdate(personId);
            personDataAccess.Delete(person);

            db.SaveChanges();
        }
    }
}