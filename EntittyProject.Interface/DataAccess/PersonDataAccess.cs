using System.Linq;
using EntityProject.Application.Interface;
using EntityProject.Application.PersonManagment;
using EntityProject.Application.UserManagment;
using EntityProject.Domain.Entities;

namespace EntityProject.Persistence.DataAccess;

public class PersonDataAccess(ISearchPerson searchPerson, IDb db) : IPersonDataAccess
{
    public void Delete(Person person)
    {
        db.Delete<Person>(person);
    }

    public Person GetById(int id)
    {
        return searchPerson.Respond(new ISearchPerson.Request
        {
            Id = id
        }).SingleOrDefault(p => p.Id == id);
    }
    public Person GetForUpdate(int id)
    {
        return searchPerson.RespondForUpdate(new ISearchPerson.Request
        {
            Id = id
        }).SingleOrDefault(p => p.Id == id);
    }
}
