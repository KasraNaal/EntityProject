using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntittyProject.Application.DTO;
using EntittyProject.Application.Interface;
using EntittyProject.Application.UseCase;
using EntityProject.Application.Interface;
using EntityProject.Persistence.Contexts;
using EntityProject.Persistence.DataAccess;

namespace EndPoint.Site
{
    public partial class Default : System.Web.UI.Page
    {
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

            IDb dbContext = new DataBaseContext();
            IUserDataAccess userDataAccess = new UserDataAccess(dbContext);
            IUserValidation userValidation = new UserValidation();

            UserRegisterService userRegisterService = new UserRegisterService(userValidation, userDataAccess);

            var message = userRegisterService.RegisterUser(user);

            lblMessege.Text = message;
        }
    }
}