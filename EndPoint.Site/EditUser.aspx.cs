using Autofac;
using EntittyProject.Application.UserManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntittyProject.Application.Interface;
using static EntittyProject.Application.UserManagment.IUserDataAccess;
using static EntittyProject.Application.UserManagment.IUpdateUser;
using EntittyProject.Application.PersonManagment;

namespace EndPoint.Site
{
    public partial class EditUser : System.Web.UI.Page
    {
        public IUserDataAccess userDataAccess { get; set; }
        public IDb db { get; set; }
        public IGetUserById getUserById { get; set; }
        public IUpdateUser updateUser { get; set; }
        public ISearchPerson searchPerson { get; set; }
        public IPersonDataAccess personDataAccess { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int userId = Convert.ToInt32(Request.QueryString["id"]);

                    IGetUserById.Request request = new IGetUserById.Request
                    {
                        Id = userId
                    };

                    var user = getUserById.Execute(request);
                    var person = personDataAccess.GetById(user.User.PersonId);


                    if (user == null)
                    {
                        Response.Redirect("Default.aspx");
                    }

                    else
                    {
                        txtbFirstName.Text = person.FirstName;
                        txtbLastName.Text = person.LastName;
                        txtbUserName.Text = user.User.UserName;
                        txtbPassword.Attributes["value"] = user.User.Password;
                    }
                }
            }
            
        }

        protected void btnSubmitUser_Click(object sender, EventArgs e)
        {
            UpdateRequest updateRequest = new UpdateRequest
            {
                Id = Convert.ToInt32(Request.QueryString["id"]),
                FirstName = txtbFirstName.Text,
                LastName = txtbLastName.Text,
                UserName = txtbUserName.Text,
                Password = txtbPassword.Text
            };

            updateUser.UpdateUser(updateRequest);

            Response.Redirect("Default.aspx");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}