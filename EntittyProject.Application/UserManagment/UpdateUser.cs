using EntittyProject.Application.Interface;
using static EntittyProject.Application.UserManagment.IUpdateUser;

namespace EntittyProject.Application.UserManagment
{
    public class UpdateUser(IUserDataAccess userDataAccess, IDb db, IGetUserById getUserById) : IUpdateUser
    {

        void IUpdateUser.UpdateUser(UpdateRequest updateRequest)
        {
            var user = getUserById.Execute(new IGetUserById.Request
            {
                Id = updateRequest.Id
            });

            user.User.Person.FirstName = updateRequest.FirstName;
            user.User.Person.LastName = updateRequest.LastName;
            user.User.UserName = updateRequest.UserName;
            user.User.Password = updateRequest.Password;

            userDataAccess.UpdateUser(user.User);

            db.SaveChanges();


        }
    }
}
