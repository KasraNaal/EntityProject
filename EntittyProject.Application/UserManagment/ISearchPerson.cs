using EntittyProject.Domain.Entities;
using System.Linq;

namespace EntittyProject.Application.UserManagment
{
    public interface ISearchPerson
    {
        IQueryable<Person> Search(SearchPersonRequest request = null);

        public class SearchPersonRequest
        {
            public int? Id { get; set; }
            public string KeyWord { get; set; }
        }
    }
}
