using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProject.Domain.Entities;

namespace EntittyProject.Application.Interface
{
    public interface IUserDataAccess
    {
        void AddUser(User user);
        void UpdateUser(SearchDto searchdto);
        void DeleteUser(int id);
        bool DoesUserExist(string userName);
        bool DoesUserExist(int Id);
        IQueryable<User> Search(string searchUser);
        SearchDto GetUserById(int id);
        public class SearchDto
        {
            public User User { get; set; }
            public Person Person { get; set; }
        }
    }
}
