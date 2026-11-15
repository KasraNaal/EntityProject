using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Autofac;
using EntittyProject.Application.Interface;
using EntittyProject.Application.UseCase;
using EntittyProject.Application.UserManagment;
using EntityProject.Application.Interface;
using EntityProject.Persistence.Contexts;
using EntityProject.Persistence.DataAccess;
using EntityProject.Domain.Entities;
using System.Net;


namespace EndPoint.Site
{
    public partial class Default : System.Web.UI.Page
    {
        public IUserRegisterService userRegisterService { get; set; }
        public IUserValidation userValidation { get; set; }
        public IUserDataAccess userDataAccess { get; set; }
        public ISearchUsers searchUsers { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            userRegisterService = Global.Container.Resolve<IUserRegisterService>();
            userDataAccess = Global.Container.Resolve<IUserDataAccess>();
            searchUsers = Global.Container.Resolve<ISearchUsers>();
        }

        //protected void btnSubmitUser_Click(object sender, EventArgs e)
        //{
        //    UserRegisterRequest user = new UserRegisterRequest
        //    {
        //        FirstName = txtbFirstName.Text,
        //        LastName = txtbLastName.Text,
        //        UserName = txtbUserName.Text,
        //        Password = txtbPassword.Text
        //    };


        //        var message = userRegisterService.RegisterUser(user);

        //        lblMessege.Text = message;

        //}

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    userDataAccess.DeleteUser(int.Parse(txtbDeleteUserId.Text));

        //    lblDeleteMessage.Text = "User deleted successfully!";
        //}

        protected void dgvShowUsersRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeleteUser")
            {
                userDataAccess.DeleteUser(userId);
            }

            else if (e.CommandName == "EditUser")
            {
                Response.Redirect($"EditUser.aspx?id={userId}");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string searchUser = txtbSearchUserName.Text;
            List<User> searchResults = userDataAccess.Search(searchUser).ToList();

            dgvShowUsers.DataSource = searchResults;
            dgvShowUsers.DataBind();
        }
    }
}