using Autofac;
using EntittyProject.Application.UserManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EndPoint.Site
{
    public partial class AddUser : System.Web.UI.Page
    {
        public IUserRegisterService userRegisterService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            UserRegisterRequest user = new UserRegisterRequest
            {
                FirstName = txtbFirstName.Text,
                LastName = txtbLastName.Text,
                UserName = txtbUserName.Text,
                Password = txtbPassword.Text
            };


            var message = userRegisterService.RegisterUser(user);

            lblMessege.Text = message;
        }

        protected void btnSubmitUser_Click(object sender, EventArgs e)
        {
            UserRegisterRequest user = new UserRegisterRequest
            {
                FirstName = txtbFirstName.Text,
                LastName = txtbLastName.Text,
                UserName = txtbUserName.Text,
                Password = txtbPassword.Text
            };


            var message = userRegisterService.RegisterUser(user);

            lblMessege.Text = message;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}