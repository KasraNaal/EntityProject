using System.Linq;
using EntityProject.Application.Interface;
using EntityProject.Application.PersonManagment;
using EntityProject.Application.UserManagment;
using EntityProject.Domain.Entities;

namespace EntityProject.Persistence.DataAccess
{
    public class SearchPerson(IDb db) : ISearchPerson
    {
        public IQueryable<Person> Respond(ISearchPerson.Request request = null)
        {
            return Respond(request, db.Query<Person>());
        }

        public IQueryable<Person> RespondForUpdate(ISearchPerson.Request request = null)
        {
            return Respond(request, db.Set<Person>());
        }

        private IQueryable<Person> Respond(ISearchPerson.Request request, IQueryable<Person> items)
        {
            if (request is null)
            {
                return items;
            }

            if (request.Id.HasValue)
            {
                items = items.Where(i => i.Id == request.Id);
            }

            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                items = items.Where(i => i.FirstName.Contains(request.KeyWord) ||
                                         i.LastName.Contains(request.KeyWord));
            }

            return items;
        }
    }
}