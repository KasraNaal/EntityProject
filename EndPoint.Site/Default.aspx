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
        <asp:RequiredFieldValidator ID="fvFirstName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtbFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="evFirstName" runat="server" ErrorMessage="Enter a-z or A-Z" ValidationExpression="^[a-zA-Z]+$" ControlToValidate="txtbFirstName" ForeColor="Red" Display="Dynamic" EnableClientScript="false"></asp:RegularExpressionValidator>
        <br />

        <asp:Label ID="lblLastName" runat="server" Text="LastName: "></asp:Label>
        <asp:TextBox ID="txtbLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="fvLastName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtbLastName" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="evLastName" runat="server" ErrorMessage="Enter a-z or A-Z" ValidationExpression="^[a-zA-Z]+$" ControlToValidate="txtbLastName" ForeColor="Red" Display="Dynamic" EnableClientScript="false"></asp:RegularExpressionValidator>   
        <br />

        <asp:Label ID="lblUserName" runat="server" Text="UserName: "></asp:Label>
        <asp:TextBox ID="txtbUserName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="fvUserName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtbUserName" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="evUserName" runat="server" ErrorMessage="a-z, A-Z and (@,#,$) are allowed" ValidationExpression="^[a-zA-Z@#$\d]+$" ControlToValidate="txtbUserName" ForeColor="Red" Display="Dynamic" EnableClientScript="false"></asp:RegularExpressionValidator>
        <br />

        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtbPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="fvPassword" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtbPassword" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="evPassword" runat="server" ErrorMessage="lower, upper, number and (@,#,$) must be entered" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$])[a-zA-Z\d@#$]+$" ControlToValidate="txtbPassword" ForeColor="Red" Display="Dynamic" EnableClientScript="false"></asp:RegularExpressionValidator>            
        <br />

        <asp:Button ID="btnSubmitUser" runat="server" OnClick="btnSubmitUser_Click" Text="Submit" />
        <br />

        <asp:Label ID="lblMessege" runat="server"></asp:Label>
    </form>
</body>
</html>
