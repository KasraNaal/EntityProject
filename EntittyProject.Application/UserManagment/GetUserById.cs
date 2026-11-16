using EntittyProject.Application.Interface;
using EntityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntittyProject.Application.UserManagment.IGetUserById;

namespace EntittyProject.Application.UserManagment
{
    public class GetUserById : IGetUserById
    {
        private readonly IUserDataAccess _userDataAccess;

        public GetUserById(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public User Execute(Request request)
        {
            if (request is null)
            {
                return null;
            }

            if (request.Id <= 0)
            {
                return null;
            }

            User user = _userDataAccess.GetUserById(request.Id);

            return user;


        }
    }
}
