using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Autofac;
using EntittyProject.Application.DTO;
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
        public IUserValidation uservakl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmitUser_Click(object sender, EventArgs e)
        {
            UserRegisterDto user = new UserRegisterDto
            {
                FirstName = txtbFirstName.Text,
                LastName = txtbLastName.Text,
                UserName = txtbUserName.Text,
                Password = txtbPassword.Text
            };

          
                var message = userRegisterService.RegisterUser(user);

                lblMessege.Text = message;
            
        }
    }
}