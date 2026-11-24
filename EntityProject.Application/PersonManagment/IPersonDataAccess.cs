using EntityProject.Domain.Entities;

namespace EntityProject.Application.PersonManagment;

public interface IPersonDataAccess
{
    public void Delete(Person person);
    Person GetForUpdate(int id);
    public Person GetById(int id);
}
