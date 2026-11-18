using EntityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntittyProject.Application.Interface.IUserDataAccess;

namespace EntittyProject.Application.UserManagment
{
    public interface ISearchUsers
    {
        IQueryable<SearchDto> Respond(Request request = null);

        class Request
        {
            public int? Id { get; set; }
            public string Keyword { get; set; }
            public SearchPersonRequest PersonRequest { get; set; }

        }
    }
}
