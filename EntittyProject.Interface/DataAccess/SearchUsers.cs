using EntittyProject.Application.Interface;
using EntittyProject.Application.UserManagment;
using EntityProject.Application.Interface;
using EntityProject.Domain.Entities;
using System;
using System.Linq;
using System.Security.Cryptography;
using static EntittyProject.Application.Interface.IUserDataAccess;
using static EntittyProject.Application.UserManagment.ISearchUsers;


namespace EntityProject.Persistence.DataAccess
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

                items =
                    from user in items
                    join person in people
                    on user.User.PersonId equals person.Id into personGroup
                    from person in personGroup.DefaultIfEmpty()
                    where person != null
                    select new SearchDto
                    {
                        User = user.User,
                        Person = person
                    };
            } 

            return items;
        }
    }
}
