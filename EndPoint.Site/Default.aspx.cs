using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Autofac;
using EntittyProject.Application.UserManagment;
using System.Net;


namespace EndPoint.Site
{
    public partial class Default : System.Web.UI.Page
    {
        public IUserRegisterService userRegisterService { get; set; }
        public IUserValidation userValidation { get; set; }
        public IUserDataAccess userDataAccess { get; set; }
        public ISearchUsers searchUsers { get; set; }
        public IDeleteUser deleteUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        

        protected void dgvShowUsersRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeleteUser")
            {
                deleteUser.DeleteUser(userId);
            }

            else if (e.CommandName == "EditUser")
            {
                Response.Redirect($"EditUser.aspx?id={userId}");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var result = searchUsers.Respond(new ISearchUsers.Request { Keyword = txtbSearchUserName.Text })
                .Select(u => new ShowUserDto
                {
                    Id = u.Id,
                    FirstName = u.Person.FirstName,
                    LastName = u.Person.LastName,
                    UserName = u.UserName
                }).ToList();

            dgvShowUsers.DataSource = result;
            dgvShowUsers.DataBind();
        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }
    }
}