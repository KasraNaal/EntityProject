using System.Linq;
using EntityProject.Application.Interface;
using EntityProject.Application.PersonManagment;
using EntityProject.Application.UserManagment;
using EntityProject.Domain.Entities;
using static EntityProject.Application.UserManagment.ISearchUsers;


namespace EntityProject.Persistence.DataAccess;

public class SearchUsers(IDb db, ISearchPerson searchPerson) : ISearchUsers
{
    public IQueryable<User> Respond(Request request)
    {
        return Respond(request, db.Query<User>());
    }

    public IQueryable<User> RespondForUpdate(Request request = null)
    {
        return Respond(request, db.Set<User>());
    }

    private IQueryable<User> Respond(Request request, IQueryable<User> items)
    {
        if (request == null)
            return items;

        if (request.Id.HasValue)
            items = items.Where(i => i.Id == request.Id);

        if (!string.IsNullOrEmpty(request.Keyword))
            items = items.Where(i => i.UserName.Contains(request.Keyword)
                                  || i.Person.FirstName.Contains(request.Keyword)
                                  || i.Person.LastName.Contains(request.Keyword)
                );

        if (request.PersonRequest != null)
            items = from user in items
                join person in searchPerson.Respond(request.PersonRequest)
                    on user.PersonId equals person.Id
                select user;

        return items;
    }
}