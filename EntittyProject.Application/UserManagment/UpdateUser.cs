using EntittyProject.Application.Interface;
using EntittyProject.Application.PersonManagment;
using static EntittyProject.Application.UserManagment.IUpdateUser;

namespace EntittyProject.Application.UserManagment
{
    public class UpdateUser(IUserDataAccess userDataAccess, IDb db, IGetUserById getUserById, IPersonDataAccess personDataAccess) : IUpdateUser
    {

        void IUpdateUser.UpdateUser(UpdateRequest updateRequest)
        {
            var user = getUserById.Execute(new IGetUserById.Request
            {
                Id = updateRequest.Id
            });

            if(user?.User == null)
            {
                throw new System.Exception("User not found!");
            }

            var person = personDataAccess.GetById(user.User.PersonId);

            if(person == null)
            {
                throw new System.Exception("Person not foun!");
            }

            person.FirstName = updateRequest.FirstName;
            person.LastName = updateRequest.LastName;
            user.User.UserName = updateRequest.UserName;
            user.User.Password = updateRequest.Password;
            user.User.Person = person;

            userDataAccess.UpdateUser(user.User);
            personDataAccess.Update(person);

            db.SaveChanges();


        }
    }
}
