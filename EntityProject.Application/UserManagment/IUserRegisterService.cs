namespace EntityProject.Application.UserManagment;

public interface IUserRegisterService
{
    string RegisterUser(UserRegisterRequest user);
}
public class UserRegisterRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
