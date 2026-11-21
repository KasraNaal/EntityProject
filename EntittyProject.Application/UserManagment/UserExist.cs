namespace EntittyProject.Application.UserManagment
{
    public class UserExist(IUserDataAccess userDataAccess) : IUserExist
    {
        public bool IUserExist(string userName)
        {
            return userDataAccess.DoesUserExist(userName);
        }
    }
}
