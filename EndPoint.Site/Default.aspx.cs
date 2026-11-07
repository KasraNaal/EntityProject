using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntittyProject.Application.DTO;

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
        }
    }
}