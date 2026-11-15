using Autofac;
using EntittyProject.Application.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EndPoint.Site
{
    public partial class EditUser : System.Web.UI.Page
    {

        public IUserDataAccess userDataAccess { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            userDataAccess = Global.Container.Resolve<IUserDataAccess>();


            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int userId = Convert.ToInt32(Request.QueryString["id"]);

                var user = userDataAccess.GetUserById(userId);


                if (user == null)
                {
                    Response.Redirect("Default.aspx");
                }

                else
                {
                    txtbFirstName.Text = user.Person.FirstName;
                    txtbLastName.Text = user.Person.LastName;
                    txtbUserName.Text = user.UserName;
                }
            }
        }
    }
}