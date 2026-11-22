using EntittyProject.Application.Interface;
using EntittyProject.Application.PersonManagment;
using EntittyProject.Application.UserManagment;
using EntittyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyProject.Persistence.DataAccess
{
    public class PersonDataAccess(ISearchPerson searchPerson, IDb db) : IPersonDataAccess
    {
        public void Delete(int id)
        {
            Person person = GetById(id);
            db.Delete<Person>(person);
        }

        public Person GetById(int id)
        {
            Person person = searchPerson.Search(new ISearchPerson.SearchPersonRequest
            {
                Id = id
            }).SingleOrDefault(p => p.Id == id);

            return person;
        }

        public void Update(Person person)
        {
            db.Update<Person>(person);
        }
    }
}
