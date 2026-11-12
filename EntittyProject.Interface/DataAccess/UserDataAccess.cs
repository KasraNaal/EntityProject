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


namespace EntityProject.Persistence.DataAccess
{
    public class UserDataAccess: IUserDataAccess
    {
        private readonly IDb _db;

        public UserDataAccess(IDb db)
        {
            _db = db;
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
        }

        public List<User> Load()
        {
            return _db.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            var existingUser = _db.Users.Find(user.Id);
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
            var user = _db.Users.Find(Id);
            if (user != null)
            {
                _db.Users.Remove(user);
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
