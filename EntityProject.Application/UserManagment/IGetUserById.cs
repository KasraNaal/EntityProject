using EntityProject.Domain.Entities;

namespace EntityProject.Application.UserManagment;

public interface IGetUserById
{
    User Execute(int id);
    
}
