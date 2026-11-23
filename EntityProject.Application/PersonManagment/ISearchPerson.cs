using System.Linq;
using EntityProject.Domain.Entities;

namespace EntityProject.Application.PersonManagment
{
    public interface ISearchPerson
    {
        IQueryable<Person> Respond(ISearchPerson.Request request = null);
        IQueryable<Person> RespondForUpdate(ISearchPerson.Request request = null);

        public class Request
        {
            public int? Id { get; set; }
            public string KeyWord { get; set; }
        }
    }
}
