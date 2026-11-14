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
        <div>
        </div>
        

        <asp:Label ID="lblDelete" runat="server" Text="Delete User"></asp:Label>
        <br />

        <asp:Label ID="lblDeleteUser" runat="server" Text="UserId: "></asp:Label>
        <asp:TextBox ID="txtbDeleteUserId" runat="server" ValidationGroup="DeleteGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="fvDeleteUser" runat="server" ErrorMessage="Enter something BROOO" ControlToValidate="txtbDeleteUserId" ForeColor="Red" Display="Dynamic" ValidationGroup="DeleteGroup"></asp:RequiredFieldValidator>

        <br />

        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete " ValidationGroup="DeleteGroup" class="btn-text theme-danger"/>
        <br />

        <asp:Label ID="lblDeleteMessage" runat="server" ValidationGroup="DeleteGroup"></asp:Label>
        <br />
        <br />


        <asp:Label ID="lblSearch" runat="server" Text="Search User"></asp:Label>
        <br />

        <asp:Label ID="lblSearchUser" runat="server" Text="UserName: "></asp:Label>
        <asp:TextBox ID="txtbSearchUserName" runat="server" ValidationGroup="SearchGroup"></asp:TextBox>
        <br />

        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" ValidationGroup="SearchGroup" class="btn-text theme-primary"/>
        <br />
        <br />

        <asp:GridView ID="dgvShowUsers" runat="server" AutoGenerateColumns="False">
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
    </form>
</body>
</html>
