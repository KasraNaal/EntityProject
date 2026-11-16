using EntityProject.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using EntityProject.Domain.Entities;
using EntittyProject.Application.Interface;
using EntittyProject.Application.UserManagment;
using System.Data.Entity;


namespace EntityProject.Persistence.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly IDb _db;
        private readonly ISearchUsers _searchUsers;

        public UserDataAccess(IDb db, ISearchUsers searchUsers)
        {
            _db = db;
            _searchUsers = searchUsers;
        }

        public void AddUser(User user)
        {
            _db.Add(user);
        }

        public void UpdateUser(User user)
        {
            _db.Update<User>(user);
            _db.Update<Person>(user.Person);

            _db.SaveChanges();
        }

        public void DeleteUser(int Id)
        {
            var user = GetUserById(Id);

            if (user != null)
            {
                var person = user.Person;

                _db.Delete(user);
                _db.Delete(person);

                _db.SaveChanges();
            }
        }

        public bool DoesUserExist(string userName)
        {
            return Search().Any(u => u.UserName == userName);
        }

        public bool DoesUserExist(int Id)
        {
            return Search().Any(u => u.Id == Id);
        }

        public IQueryable<User> Search(string searchUser = null)
        {
            if (string.IsNullOrWhiteSpace(searchUser))
            {
                return _db.Query<User>();
            }

            return _db.Query<User>()
                .Where(s => s.Person.FirstName.ToUpper().Contains(searchUser) ||
                            s.Person.LastName.ToUpper().Contains(searchUser) ||
                            s.UserName.ToUpper().Contains(searchUser));
        }

        public User GetUserById(int id)
        {
            return Search().Include(u => u.Person).FirstOrDefault(u => u.Id == id);
        }
    }
}
