using EntityProject.Domain.Entities;

namespace EntityProject.Application.UserManagment
{
    public interface IUserDataAccess
    {
        void Add(User user);
        User GetForUpdate(int id);
        void Delete(User user);
        User GetById(int id);
    }
}
