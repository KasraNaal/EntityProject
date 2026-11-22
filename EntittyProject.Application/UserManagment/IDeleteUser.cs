namespace EntittyProject.Application.UserManagment
{
    public interface IDeleteUser
    {
        void DeleteUser(int userId);

        class DeleteRequest
        {
            public int Id { get; set; }
        }
    }
}
