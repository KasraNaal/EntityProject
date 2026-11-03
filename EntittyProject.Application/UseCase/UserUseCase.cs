using EntityProject.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using EntityProject.Domain.Entities;


namespace EntityProject.Application.Usecase.UserUseCase
{
    public class UserUseCase
    {
        private readonly IDataBaseContext _context;

        public UserUseCase(IDataBaseContext context)
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
            var existingUser = _context.Users.Find(user.UserId);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.Birthday = user.Birthday;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
