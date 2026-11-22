using EntittyProject.Application.Interface;
using EntittyProject.Application.PersonManagment;
using EntittyProject.Domain.Entities;
using System;
using static EntittyProject.Application.UserManagment.IGetUserById;

namespace EntittyProject.Application.UserManagment
{
    public class DeleteUser(IUserDataAccess userDataAccess, IDb db, IGetUserById getUserById, IPersonDataAccess personDataAccess) : IDeleteUser
    {
        void IDeleteUser.DeleteUser(int userId, int personId)
        {
            if (getUserById.Execute(new IGetUserById.Request
            {
                Id = userId
            }) is null)
            {
                throw new Exception("User not found");
            }

            userDataAccess.DeleteUser(userId);
            personDataAccess.Delete(personId);
            db.SaveChanges();
        }
    }
}
