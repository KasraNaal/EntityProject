namespace EntittyProject.Application.UserManagment
{
    public interface IGetUserById
    {
        SearchDto Execute(Request request);
        class Request
        {
            public int Id { get; set; }
        }
    }
}
