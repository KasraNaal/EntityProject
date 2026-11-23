using System.Linq;
using EntityProject.Application.Interface;
using EntityProject.Application.UserManagment;
using EntityProject.Domain.Entities;

namespace EntityProject.Persistence.DataAccess
{
    public class UserDataAccess(IDb db, ISearchUsers searchUsers) : IUserDataAccess
    {
        public void Add(User user)
        {
            db.Add(user);
        }

        public User GetForUpdate(int id)
        {
            return searchUsers.RespondForUpdate(new ISearchUsers.Request { Id = id }).SingleOrDefault();
        }

        public void Delete(User user)
        {
            db.Delete(user);
        }

        public User GetById(int id)
        {
            return searchUsers.Respond(new ISearchUsers.Request { Id = id }).SingleOrDefault();
        }
    }
}