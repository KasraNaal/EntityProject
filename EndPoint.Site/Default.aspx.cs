using System;
using System.Linq;
using System.Web.UI.WebControls;
using EndPoint.Site.Extensions;
using EntityProject.Application.Exceptions;
using EntityProject.Application.UserManagment;

namespace EndPoint.Site
{
    public partial class Default : System.Web.UI.Page
    {
        public ISearchUsers searchUsers { get; set; }
        public IDeleteUser deleteUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadUsers();
        }

        protected void dgvShowUsersRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteUser")
                {
                    string[] ids = e.CommandArgument.ToString().Split(',');

                    int userId = Convert.ToInt32(ids[0]);

                    deleteUser.Delete(userId);
                    
                }

                else if (e.CommandName == "EditUser")
                {
                    int userId = Convert.ToInt32(e.CommandArgument);

                    Response.Redirect($"EditUser.aspx?id={userId}");
                }
            }
            catch (AppException ex)
            {
                lblMessage.ShowError(ex.Message);
            }
            catch (Exception)
            {
                lblMessage.ShowError("Unexpected error happend. Please try again later!");
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dgvShowUsers.PageIndex = 0;
            LoadUsers();
        }

        protected void dgvShowUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvShowUsers.PageIndex = e.NewPageIndex;
            LoadUsers();
        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }

        private void LoadUsers()
        {
            var query = searchUsers.Respond(new ISearchUsers.Request
            {
                Keyword = txtbSearchUserName.Text
            });

            int totalCount = query.Count();
            dgvShowUsers.VirtualItemCount = totalCount;

            if (dgvShowUsers.PageIndex > 0 && dgvShowUsers.PageIndex * dgvShowUsers.PageSize >= totalCount)
                dgvShowUsers.PageIndex--;

            var result = query
                .OrderBy(u => u.Id)
                .Skip(dgvShowUsers.PageIndex * dgvShowUsers.PageSize)
                .Take(dgvShowUsers.PageSize)
                .Select(u => new ShowUserDto
                {
                    Id = u.Id,
                    FirstName = u.Person.FirstName,
                    LastName = u.Person.LastName,
                    UserName = u.UserName
                }).ToList();

            dgvShowUsers.DataSource = result;
            dgvShowUsers.DataBind();
        }
    }
}