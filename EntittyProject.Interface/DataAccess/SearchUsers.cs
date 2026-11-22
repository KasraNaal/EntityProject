using System.Linq;
using EntittyProject.Application.Interface;
using EntittyProject.Application.UserManagment;
using EntittyProject.Domain.Entities;
using static EntittyProject.Application.UserManagment.ISearchUsers;


namespace EntittyProject.Persistence.DataAccess
{
    public class SearchUsers(IDb db, ISearchPerson searchPerson) : ISearchUsers
    {
        public IQueryable<SearchDto> Respond(Request request)
        {
            var items = db.Query<User>().Select(user => new SearchDto
            {
                User = user,
                Person = null
            });

            if (request == null)
                return items;

            if (request.Id.HasValue)
                items = items.Where(i => i.User.Id == request.Id);

            if (!string.IsNullOrEmpty(request.Keyword))
                items = items.Where(i => i.User.UserName == request.Keyword);

            if (request.PersonRequest != null)
            {
                IQueryable<Person> people = searchPerson.Search(request.PersonRequest);

                items = from user in items
                        join person in searchPerson.Search(request.PersonRequest)
                        on user.PersonId equals person.Id
                        select user;
            } 

            return items;
        }
    }
}
