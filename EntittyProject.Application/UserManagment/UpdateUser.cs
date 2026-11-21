using EntittyProject.Application.Interface;
using static EntittyProject.Application.UserManagment.IUpdateUser;

namespace EntittyProject.Application.UserManagment
{
    public class UpdateUser(IUserDataAccess userDataAccess, IDb db) : IUpdateUser
    {

        SearchDto IUpdateUser.UpdateUser(UpdateRequest updateRequest)
        {
            var user = userDataAccess.GetUserById(updateRequest.Id);

            user.Person.FirstName = updateRequest.FirstName;
            user.Person.LastName = updateRequest.LastName;
            user.User.UserName = updateRequest.UserName;
            user.User.Password = updateRequest.Password;

            userDataAccess.UpdateUser(user);

            db.SaveChanges();

            return user;
        }
    }
}
