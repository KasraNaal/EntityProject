using System.Linq;
using EntittyProject.Application.Interface;
using EntittyProject.Application.UserManagment;
using EntittyProject.Domain.Entities;


namespace EntittyProject.Persistence.DataAccess
{
    public class UserDataAccess(IDb db, IGetUserById getUserById) : IUserDataAccess
    {
        public void AddUser(User user)
        {
            db.Add(user);
        }

        public void UpdateUser(User user)
        {
            db.Update<User>(user);
            db.Update<Person>(user.Person);
        }

        public void DeleteUser(int Id)
        {
            var response = getUserById.Execute(new IGetUserById.Request
            {
                Id = Id
            });

            var person = response.User.Person;

            db.Delete(response.User);
            db.Delete(person);

            db.SaveChanges();
        }
    }
}
