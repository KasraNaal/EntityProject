using EntittyProject.Application.Interface;
using EntityProject.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
