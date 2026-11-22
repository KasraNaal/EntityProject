using EntittyProject.Domain.Entities;

namespace EntittyProject.Application.UserManagment
{
    public interface IGetUserById
    {
        Response Execute(Request request);

        class Request
        {
            public int Id { get; set; }
        }

        class Response
        {
            public User User{ get; set; }
        }
    }
}
