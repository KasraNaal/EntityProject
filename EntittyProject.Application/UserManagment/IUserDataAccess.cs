using EntittyProject.Domain.Entities;

namespace EntittyProject.Application.UserManagment
{
    public interface IUserDataAccess
    {
        void AddUser(User user);
        void UpdateUser(SearchDto searchdto);
        void DeleteUser(int id);
        bool DoesUserExist(string userName);
        bool DoesUserExist(int id);
    }
}
