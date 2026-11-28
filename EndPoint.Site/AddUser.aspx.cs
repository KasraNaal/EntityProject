using EntityProject.Application.Exceptions;
using EntityProject.Application.UserManagment;
using System;

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

            try
            {
                var message = userRegisterService.RegisterUser(user);
                lblMessege.Text = message;
            }
            catch (AppException ex)
            {
                lblMessege.Text = ex.Message;
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}