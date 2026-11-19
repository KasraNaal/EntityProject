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
                return db.Query<User>();
            }

            searchUser = searchUser.ToUpper();

            return db.Query<User>()
                .Where(s => s.Person.FirstName.ToUpper().Contains(searchUser) ||
                            s.Person.LastName.ToUpper().Contains(searchUser) ||
                            s.UserName.ToUpper().Contains(searchUser));
        }


        public SearchDto GetUserById(int id)
        {
            var user = searchUsers.Respond(new ISearchUsers.Request 
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
