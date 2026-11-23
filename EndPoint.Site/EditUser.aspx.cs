using System;
using System.Security.Authentication;
using EntityProject.Application.PersonManagment;
using EntityProject.Application.UserManagment;
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
                int userId = Convert.ToInt32(Request.QueryString["id"]);

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

                updateUser.UpdateUser(updateRequest);

                Response.Redirect("Default.aspx");
            }
            //catch (BussinessException ex)
            //{
               
            //}
            catch (Exception ex)
            {
               
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}