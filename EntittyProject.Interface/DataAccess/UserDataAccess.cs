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
        private readonly IDb _context;

        public UserDataAccess(IDb context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> Load()
        {
            return _context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int Id)
        {
            var user = _context.Users.Find(Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
