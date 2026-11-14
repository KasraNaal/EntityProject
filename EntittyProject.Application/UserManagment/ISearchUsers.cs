using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProject.Domain.Entities;

namespace EntittyProject.Application.UserManagment
{
    public interface ISearchUsers
    {
        IQueryable<User> Respond(Request request = null);

        class Request
        {
            public int? Id { get; set; }
            public string Keyword { get; set; }
            public string UserName { get; set; }

        }
    }
}
