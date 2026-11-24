using EntityProject.Domain.Entities;

namespace EntityProject.Application.UserManagment;

public class GetUserById(IUserDataAccess userDataAccess) : IGetUserById
{
    public User Execute(int id)
    {
        return userDataAccess.GetById(id);
    }
}