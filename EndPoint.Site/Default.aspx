<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EndPoint.Site.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User</title>
</head>
<body>
    <form id="GetUser" runat="server">
        <div>

        </div>
        <asp:Label ID="lblFirstName" runat="server" Text="FirstName: "></asp:Label>
        <asp:TextBox ID="txtbFirstName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblLastName" runat="server" Text="LastName: "></asp:Label>
        <asp:TextBox ID="txtbLastName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblUserName" runat="server" Text="UserName: "></asp:Label>
        <asp:TextBox ID="txtbUserName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtbPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmitUser" runat="server" OnClick="btnSubmitUser_Click" Text="Submit" />
        <br />
        <asp:Label ID="lblMessege" runat="server"></asp:Label>
    </form>
</body>
</html>
