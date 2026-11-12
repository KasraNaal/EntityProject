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


namespace EndPoint.Site
{
    public partial class Default : System.Web.UI.Page
    {
        public IUserRegisterService userRegisterService { get; set; }
        public IUserValidation userValidation { get; set; }
        public IUserDataAccess userDataAccess { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            userRegisterService = Global.Container.Resolve<IUserRegisterService>();
            userDataAccess = Global.Container.Resolve<IUserDataAccess>();
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            userDataAccess.DeleteUser(int.Parse(txtbDeleteUserId.Text));

            lblDeleteMessage.Text = "User deleted successfully!";
        }
    }
}