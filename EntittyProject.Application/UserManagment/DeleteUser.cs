using System;
using EntittyProject.Application.Interface;

namespace EntittyProject.Application.UserManagment
{
    public class DeleteUser(IUserDataAccess userDataAccess, IDb db) : IDeleteUser
    {
        void IDeleteUser.DeleteUser(int userId)
        {
            if (userDataAccess.DoesUserExist(userId))
            {
                throw new Exception("Where is User??");
            }
            userDataAccess.DeleteUser(userId);
            db.SaveChanges();
        }
    }
}
