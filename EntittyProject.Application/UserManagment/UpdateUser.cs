using EntittyProject.Application.Interface;
using EntityProject.Application.Interface;
using EntityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntittyProject.Application.UserManagment.IUpdateUser;

namespace EntittyProject.Application.UserManagment
{
    public class UpdateUser : IUpdateUser
    {
        private readonly IUserDataAccess _userDataAccess;

        public UpdateUser(IUserDataAccess userDataAccess, IDb db)
        {
            _userDataAccess = userDataAccess;
        }

        User IUpdateUser.UpdateUser(UpdateRequest updateRequest)
        {
            var user = _userDataAccess.GetUserById(updateRequest.Id);

            user.Person.FirstName = updateRequest.FirstName;
            user.Person.LastName = updateRequest.LastName;
            user.UserName = updateRequest.UserName;
            user.Password = updateRequest.Password;

            _userDataAccess.UpdateUser(user);

            return user;
        }
    }
}
