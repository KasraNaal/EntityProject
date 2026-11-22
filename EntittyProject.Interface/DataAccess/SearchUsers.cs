using System.Linq;
using EntittyProject.Application.Interface;
using EntittyProject.Application.UserManagment;
using EntittyProject.Domain.Entities;
using static EntittyProject.Application.UserManagment.ISearchUsers;


namespace EntittyProject.Persistence.DataAccess
{
    public class SearchUsers(IDb db, ISearchPerson searchPerson) : ISearchUsers
    {
        public IQueryable<User> Respond(Request request)
        {
            var items = db.Query<User>();

            if (request == null)
                return items;

            if (request.Id.HasValue)
                items = items.Where(i => i.Id == request.Id);

            if (!string.IsNullOrEmpty(request.Keyword))
                items = items.Where(i => i.UserName == request.Keyword);

            if (request.PersonRequest != null)
            {

                items = from user in items
                        join person in searchPerson.Search(request.PersonRequest)
                        on user.PersonId equals person.Id
                        select user;
            }

            return items;
        }
    }
}
