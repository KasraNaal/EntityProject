using static EntittyProject.Application.UserManagment.IUserDataAccess;
using static EntittyProject.Application.UserManagment.IGetUserById;

namespace EntittyProject.Application.UserManagment
{
    public class GetUserById(IUserDataAccess userDataAccess) : IGetUserById
    {
        public SearchDto Execute(Request request)
        {
            if (request is null)
            {
                return null;
            }

            if (request.Id <= 0)
            {
                return null;
            }

            SearchDto user = userDataAccess.GetUserById(request.Id);

            return user;
        }
    }
}
