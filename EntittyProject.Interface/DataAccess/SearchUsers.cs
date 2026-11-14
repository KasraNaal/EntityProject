using EntittyProject.Application.UserManagment;
using EntityProject.Application.Interface;
using EntityProject.Domain.Entities;
using System.Linq;
using static EntittyProject.Application.UserManagment.ISearchUsers;


namespace EntityProject.Persistence.DataAccess
{
    public class SearchUsers : ISearchUsers
    {
        private readonly IDb _db;

        public SearchUsers(IDb db)
        {
            _db = db;
        }
        public IQueryable<User> Respond(Request request)
        {
            var items = _db.Query<User>();

            if (request == null)
                return items;

            if (request.Id.HasValue)
                items = items.Where(i => i.Id == request.Id);

            if (string.IsNullOrEmpty(request.UserName) == false)
                items = items.Where(i => i.UserName == request.UserName);

            return items;
        }
    }
}
