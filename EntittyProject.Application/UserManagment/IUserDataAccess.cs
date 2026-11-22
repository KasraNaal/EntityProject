using EntittyProject.Domain.Entities;

namespace EntittyProject.Application.UserManagment
{
    public interface IUserDataAccess
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
