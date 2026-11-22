using EntittyProject.Application.Interface;
using System;

namespace EntittyProject.Application.UserManagment
{
    public class DeleteUser(IUserDataAccess userDataAccess, IDb db, IGetUserById getUserById) : IDeleteUser
    {
        void IDeleteUser.DeleteUser(int userId)
        {
            //if (userDataAccess.DoesUserExist(userId))
            //{
            //    throw new Exception("Where is User??");
            //}
            //userDataAccess.DeleteUser(userId);
            //db.SaveChanges();

            if (userId < 0)
            {
                throw new Exception("Unvalid user id");
            }

            if (getUserById.Execute(new IGetUserById.Request
            {
                Id = userId
            }) is null)
            {
                throw new Exception("User not found");
            }

            userDataAccess.DeleteUser(userId);
            db.SaveChanges();
        }
    }
}
