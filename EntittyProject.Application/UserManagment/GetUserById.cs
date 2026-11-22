using System.Linq;
using static EntittyProject.Application.UserManagment.IGetUserById;

namespace EntittyProject.Application.UserManagment
{
    public class GetUserById(ISearchUsers searchUsers) : IGetUserById
    {
        public Response Execute(Request request)
        {
            if (request is null)
            {
                return null;
            }

            if (request.Id <= 0)
            {
                return null;
            }

            return searchUsers.Respond(new ISearchUsers.Request
            {
                Id = request.Id
            }).Select(i => new Response
            {
                User = i
            }).SingleOrDefault();

        }
    }
}
