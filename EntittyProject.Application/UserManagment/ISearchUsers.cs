using System.Linq;

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
