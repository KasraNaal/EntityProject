<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EndPoint.Site.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@6.0.0-alpha.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-B/GM4XqrwHnWXNOWMbloTmrYXZg10cakYGmpfsR/bbzQ6JAJI4ihuyADKLnBgrCe" crossorigin="anonymous">
    <script type="module" src="https://cdn.jsdelivr.net/npm/bootstrap@6.0.0-alpha.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-1a/pXj49ZQ1aHEmrJ+gMw1otqoVsYwlEnlD8mIfY2TV03r20Y0CN7uqx1tQogjPL" crossorigin="anonymous"></script>
    <title>User</title>
</head>
<body>
    <form id="GetUser" runat="server">
        <div style="width: fit-content; margin: 40px auto; text-align: left;">

            <section class="card" style="min-width: 400px">
                <div class="card-body">

                    <div style="text-align: center">
                        <h4 class="card-title">Search User</h4>
                        <br />

                        <asp:Label ID="lblSearchUser" runat="server" Text="UserName: "></asp:Label>
                        <asp:TextBox ID="txtbSearchUserName" runat="server" ValidationGroup="SearchGroup"></asp:TextBox>
                        <asp:Button ID="AddUser" runat="server" Text="+" OnClick="AddUser_Click" class="btn-text theme-success" />
                        <br />

                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" ValidationGroup="SearchGroup" class="btn-text theme-primary" />
                        <br />
                        <br />

                        <div style="display: flex; justify-content: center; margin-top: 20px;">
                            <asp:GridView ID="dgvShowUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="dgvShowUsersRowCommand" CssClass="table table-dark table-bordered table-striped table-hover text-center">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="UserName" HeaderText="UserName" />

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server"
                                                CommandName="EditUser"
                                                CommandArgument='<%# Eval("Id") %>'
                                                CausesValidation="False"
                                                Style="color: #ffc107; text-decoration: none; display: inline-flex; align-items: center; justify-content: center;">
                                                <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                                    <path d="M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7"></path>
                                                    <path d="M18.5 2.5a2.121 2.121 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z"></path>
                                                </svg>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server"
                                                CommandName="DeleteUser"
                                                CommandArgument='<%# Eval("Id") %>'
                                                CausesValidation="False"
                                                OnClientClick="return confirm('Are you sure remove this user?!');"
                                                Style="color: #dc3545; text-decoration: none; display: inline-flex; align-items: center; justify-content: center;">
                                                <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                                    <polyline points="3 6 5 6 21 6"></polyline>
                                                    <path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path>
                                                    <line x1="10" y1="11" x2="10" y2="17"></line>
                                                    <line x1="14" y1="11" x2="14" y2="17"></line>
                                                </svg>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </section>
        </div>
    </form>
</body>
</html>