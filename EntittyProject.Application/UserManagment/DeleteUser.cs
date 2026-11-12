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
    public class DeleteUser : IDeleteUser
    {
        private readonly IUserDataAccess _userDataAccess;
        private readonly IDb _db;
        private readonly IUserValidation _userValidation;

        public DeleteUser(IUserDataAccess userDataAccess, IDb db, IUserValidation userValidation)
        {
            _userDataAccess = userDataAccess;
            _db = db;
            _userValidation = userValidation;
        }

        string IDeleteUser.DeleteUser(int userId)
        {
            if (_userDataAccess.DoesUserExist(userId))
            {
                _userDataAccess.DeleteUser(userId);
                _db.SaveChanges();

                return "User deleted successfully!";
            }

            return "User does not exist!";
        }
    }
}
