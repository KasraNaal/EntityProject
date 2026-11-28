using EndPoint.Site.Extensions;
using EntityProject.Application.Exceptions;
using EntityProject.Application.PersonManagment;
using EntityProject.Application.UserManagment;
using System;
using System.Security.Authentication;
using static EntityProject.Application.UserManagment.IUpdateUser;

namespace EndPoint.Site
{
    public partial class EditUser : System.Web.UI.Page
    {
        public IGetUserById getUserById { get; set; }
        public IUpdateUser updateUser { get; set; }
        public IPersonDataAccess personDataAccess { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int userId = Request.GetIntFromQueryString("id");

                try
                {
                    var user = getUserById.Execute(userId);

                    if (user == null)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        var person = personDataAccess.GetById(user.PersonId);

                        txtbFirstName.Text = person.FirstName;
                        txtbLastName.Text = person.LastName;
                        txtbUserName.Text = user.UserName;
                        txtbPassword.Attributes["value"] = user.Password;
                    }
                }
                catch(AppException ex)
                {
                    lblMessege.ShowError(ex.Message);
                }
                catch(Exception)
                {
                    lblMessege.ShowError("Unexpected error happend. Please try again later!");
                }
            }
        }

        protected void btnSubmitUser_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateRequest updateRequest = new UpdateRequest
                {
                    Id = Convert.ToInt32(Request.QueryString["id"]),
                    FirstName = txtbFirstName.Text,
                    LastName = txtbLastName.Text,
                    UserName = txtbUserName.Text,
                    Password = txtbPassword.Text
                };

                updateUser.Update(updateRequest);
                Response.Redirect("Default.aspx");
            }
            catch (AppException ex)
            {
               lblMessege.ShowError(ex.Message);
            }
            catch (Exception)
            {
                lblMessege.ShowError("Unexpected error happend. Please try again later!");
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}