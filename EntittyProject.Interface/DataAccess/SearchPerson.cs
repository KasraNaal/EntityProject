using System.Linq;
using EntittyProject.Application.Interface;
using EntittyProject.Application.UserManagment;
using EntittyProject.Domain.Entities;

namespace EntittyProject.Persistence.DataAccess
{
    public class SearchPerson(IDb db) : ISearchPerson
    {
        public IQueryable<Person> Search(SearchPersonRequest request = null)
        {
            var items = db.Query<Person>();

            if (request is null)
            {
                return items;
            }

            if(request.Id.HasValue)
            {
                items = items.Where(i => i.Id == request.Id);
            }

            if(!string.IsNullOrEmpty(request.KeyWord))
            {
                items = items.Where(i => i.FirstName.Contains(request.KeyWord)||
                                         i.LastName.Contains(request.KeyWord));
            }

            return items;
        }
    }
}
