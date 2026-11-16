using EntityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntittyProject.Application.UserManagment
{
    public interface IGetUserById
    {
        User Execute(Request request);
        class Request
        {
            public int Id { get; set; }
        }
    }
}
