using EntittyProject.Application.Interface;
using EntityProject.Application.Interface;
using EntityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyProject.Application.UserManagment
{
    public class SearchPerson : ISearchPerson
    {
        private readonly IUserDataAccess _userDataAccess;
        private readonly IDb _db;

        public SearchPerson(IUserDataAccess userDataAccess, IDb db)
        {
            _userDataAccess = userDataAccess;
            _db = db;
        }

        public List<Person> Search(SearchPersonRequest request)
        {
            if(request.Id.HasValue)
            {
                List<Person> Persons = new List<Person>();
                

            }

            return null;
        }
    }
}
