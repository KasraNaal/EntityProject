using System.Linq;
using EntityProject.Application.PersonManagment;
using EntityProject.Domain.Entities;

namespace EntityProject.Application.UserManagment
{
    public interface ISearchUsers
    {
        IQueryable<User> Respond(Request request = null);
        IQueryable<User> RespondForUpdate(Request request = null);

        class Request
        {
            public int? Id { get; set; }
            public string Keyword { get; set; }
            public ISearchPerson.Request PersonRequest { get; set; }
        }
    }
}
