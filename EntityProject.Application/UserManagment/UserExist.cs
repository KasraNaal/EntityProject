using System.Linq;

namespace EntityProject.Application.UserManagment;

public class UserExist(ISearchUsers searchUser) : IIsUserExist
{
    public bool IsUserExist(string userName)
    {
        return searchUser.Respond(new ISearchUsers.Request
        {
            Keyword = userName
        }).Any();
    }
}
