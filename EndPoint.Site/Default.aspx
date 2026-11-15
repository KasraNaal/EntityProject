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
        <div style="width: 450px; margin: 40px auto; text-align: left;">

            <section class="card" style="max-width: 400px">
                <div class="card-body">

                    <div style="text-align: center">
                        <h4 class="card-title">Search User</h4>
                        <br />
                        <div>
                        </div>


                        <asp:Label ID="lblSearchUser" runat="server" Text="UserName: "></asp:Label>
                        <asp:TextBox ID="txtbSearchUserName" runat="server" ValidationGroup="SearchGroup"></asp:TextBox>
                        <br />

                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" ValidationGroup="SearchGroup" class="btn-text theme-primary" />
                        <br />
                        <br />

                        <div style="display: flex; justify-content: center; margin-top: 20px;">
                            <asp:GridView ID="dgvShowUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="dgvShowUsersRowCommand" CssClass="table table-dark table-bordered table-striped table-hover text-center">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                    <asp:BoundField DataField="PersonId" HeaderText="PersonId" SortExpression="PersonId" />
                                    <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:EntityProjectDataBase-FirstConnectionString2 %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:EntityProjectDataBase-FirstConnectionString2 %>" ProviderName="<%$ ConnectionStrings:EntityProjectDataBase-FirstConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [People]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EntityProjectDataBase-FirstConnectionString %>" ProviderName="<%$ ConnectionStrings:EntityProjectDataBase-FirstConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>

                        </div>

                    </div>
                </div>

            </section>
        </div>


    </form>
</body>
</html>
