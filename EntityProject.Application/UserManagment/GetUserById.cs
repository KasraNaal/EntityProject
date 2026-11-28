using EntityProject.Application.Exceptions;
using EntityProject.Application.Extensions;
using EntityProject.Domain.Entities;

namespace EntityProject.Application.UserManagment;

public class GetUserById(IUserDataAccess userDataAccess) : IGetUserById
{
    public User Execute(int id)
    {
        id.IsUserIdValidate("userId");

        return userDataAccess.GetById(id);
    }
}