using EntityProject.Domain.Entities;

namespace EntityProject.Application.UserManagment;

public class GetUserById(IUserDataAccess userDataAccess) : IGetUserById
{
    public User Execute(int id)
    {
        if (id <= 0)
            throw new AppException("Invalid userId!");

        return userDataAccess.GetById(id);
    }
}