using EntittyProject.Domain.Entities;

namespace EntittyProject.Application.PersonManagment
{
    public interface IPersonDataAccess
    {
        public void Delete(int id);
        public void Update(Person person);
        public Person GetById(int id);
    }
}
