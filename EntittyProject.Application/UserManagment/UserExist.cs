using System.Data.Entity;
using System.Linq;

namespace EntittyProject.Application.UserManagment
{
    public class UserExist(ISearchUsers searchUser) : IUserExist
    {
        public bool IsUserExist(string userName)
        {
            return searchUser.Respond(new ISearchUsers.Request
            {
                Keyword = userName
            }).Any();
        }
    }
}
