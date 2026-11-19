using EntittyProject.Application.Interface;
using EntittyProject.Application.UserManagment;
using EntityProject.Application.Interface;
using EntityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntittyProject.Application.Interface.IUserDataAccess;


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

        public void UpdateUser(SearchDto searchdto)
        {
            _db.Update<User>(searchdto.User);
            _db.Update<Person>(searchdto.Person);
        }

        public void DeleteUser(int Id)
        {
            var user = GetUserById(Id);

            var person = user.Person;

            _db.Delete(user.User);
            _db.Delete(person);

            _db.SaveChanges();
        }

        public bool DoesUserExist(string userName)
        {
            return Search().Any(u => u.UserName == userName);
        }

        public bool DoesUserExist(int Id)
        {
            return Search().Any(u => u.Id == Id);
        }

        public IQueryable<User> Search(string searchUser = null)        // remove
        {
            if (string.IsNullOrWhiteSpace(searchUser))
            {
                return _db.Query<User>();
            }

            searchUser = searchUser.ToUpper();

            return _db.Query<User>()
                .Where(s => s.Person.FirstName.ToUpper().Contains(searchUser) ||
                            s.Person.LastName.ToUpper().Contains(searchUser) ||
                            s.UserName.ToUpper().Contains(searchUser));
        }


        public SearchDto GetUserById(int id)
        {
            var user = _searchUsers.Respond(new ISearchUsers.Request 
            { 
                Id = id,
                PersonRequest = new SearchPersonRequest()
            }).FirstOrDefault();

            if (user is null)
            {
                return null;
            }

            return new SearchDto
            {
                User = user.User,
                Person = user.Person
            };
        }
    }
}
