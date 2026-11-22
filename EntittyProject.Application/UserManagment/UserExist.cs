using System.Data.Entity;
using System.Linq;

﻿namespace EntittyProject.Application.UserManagment
{
    public class UserExist(IUserDataAccess userDataAccess) : IUserExist
    {
        public bool IUserExist(string userName)
        {
            return userDataAccess.DoesUserExist(userName);
        }
    }
}
