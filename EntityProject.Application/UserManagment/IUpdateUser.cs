namespace EntityProject.Application.UserManagment
{
    public interface IUpdateUser
    {
        void Update(UpdateRequest updateRequest);

        class UpdateRequest
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
