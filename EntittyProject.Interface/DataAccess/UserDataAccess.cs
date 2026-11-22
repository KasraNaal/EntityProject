using System.Linq;
using EntittyProject.Application.Interface;
using EntittyProject.Application.UserManagment;
using EntittyProject.Domain.Entities;


namespace EntittyProject.Persistence.DataAccess
{
    public class UserDataAccess(IDb db, ISearchUsers searchUsers) : IUserDataAccess
    {
        public void AddUser(User user)
        {
            db.Add(user);
        }

        public void UpdateUser(SearchDto searchdto)
        {
            db.Update<User>(searchdto.User);
            db.Update<Person>(searchdto.Person);
        }

        public void DeleteUser(int Id)
        {
            var user = GetUserById(Id);

            var person = user.Person;

            db.Delete(user.User);
            db.Delete(person);

            db.SaveChanges();
        }
    }
}
