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

        public List<User> Load()
        {
            return _searchUsers.Respond().ToList();
        }

        public void UpdateUser(User user)
        {
            var existingUser = _searchUsers.Respond(new ISearchUsers.Request
            {
                Id = user.Id
            }).SingleOrDefault();

            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                _db.SaveChanges();
            }
        }

        public void DeleteUser(int Id)
        {
            var user = _db.Find(Id);
            if (user != null)
            {
                _db.Remove(user);
                _db.SaveChanges();
            }
        }

        public bool DoesUserExist(string userName)
        {
            return _db.Users.Any(u => u.UserName == userName);
        }

        public bool DoesUserExist(int Id)
        {
            return _db.Users.Any(u => u.Id == Id);
        }

        public List<User> Search(string searchUser = null)
        {
            if (string.IsNullOrWhiteSpace(searchUser))
            {
                return _db.Query<User>().ToList();
            }

            return _db.Users
                .Where(s => s.UserName.ToUpper().Contains(searchUser)
                         || s.FirstName.ToUpper().Contains(searchUser)
                         || s.LastName.ToUpper().Contains(searchUser)).ToList();
        }
    }
}
