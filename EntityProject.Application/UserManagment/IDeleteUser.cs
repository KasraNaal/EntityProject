namespace EntityProject.Application.UserManagment
{
    public interface IDeleteUser
    {
        void DeleteUser(int userId, int personId);

        class DeleteRequest
        {
            public int Id { get; set; }
        }
    }
}
