using EntityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntittyProject.Application.Interface.IUserDataAccess;

namespace EntittyProject.Application.UserManagment
{
    public interface IUpdateUser
    {
        SearchDto UpdateUser(UpdateRequest updateRequest);

        class UpdateRequest
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
