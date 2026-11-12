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
        <asp:TextBox ID="txtbPassword" runat="server" ValidationGroup="RegisterGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="fvPassword" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtbPassword" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="evPassword" runat="server" ErrorMessage="lower, upper, number and (@,#,$) must be entered" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$])[a-zA-Z\d@#$]+$" ControlToValidate="txtbPassword" ForeColor="Red" Display="Dynamic" EnableClientScript="false"></asp:RegularExpressionValidator>            
        <br />

        <asp:Label ID="lblConfirmPassword" runat="server" style="direction: ltr" Text="Confirm Password: "></asp:Label>
        <asp:TextBox ID="txtbConfirmPassword" runat="server" ValidationGroup="RegisterGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="fvConfirmPassword" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtbConfirmPassword" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cvConfirmPassword" runat="server" ErrorMessage="not matched" ControlToValidate="txtbConfirmPassword" ControlToCompare="txtbPassword" Operator="Equal" Type="String" ForeColor="Red" Display="Dynamic" EnableClientScript="false"></asp:CompareValidator>
        <br />

        <asp:Button ID="btnSubmitUser" runat="server" OnClick="btnSubmitUser_Click" Text="Submit" ValidationGroup="RegisterGroup"/>
        <br />

        <asp:Label ID="lblMessege" runat="server" ValidationGroup="RegisterGroup"></asp:Label>
        <br />
        <br />


        <asp:Label ID="lblDelete" runat="server" Text="Delete User"></asp:Label>
        <br />

        <asp:Label ID="lblDeleteUser" runat="server" Text="UserId: "></asp:Label>
        <asp:TextBox ID="txtbDeleteUserId" runat="server" ValidationGroup ="DeleteGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="fvDeleteUser" runat="server" ErrorMessage="Enter something BROOO" ControlToValidate="txtbDeleteUserId" ForeColor="Red" Display="Dynamic" ValidationGroup ="DeleteGroup"></asp:RequiredFieldValidator>

        <br />

        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete " ValidationGroup="DeleteGroup"/>
        <br />

        <asp:Label ID="lblDeleteMessage" runat="server" ValidationGroup="DeleteGroup"></asp:Label>
        <br />
        <br />


        <asp:Label ID="lblSearch" runat="server" Text="Search User"></asp:Label>
        <br />

        <asp:Label ID="lblSearchUser" runat="server" Text="UserName: "></asp:Label>
        <asp:TextBox ID="txtbSearchUserName" runat="server" ValidationGroup="SearchGroup"></asp:TextBox>
        <br />

        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" ValidationGroup="SearchGroup"/>
        <br />
        <br />

        <asp:GridView ID="dgvShowUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EntityProjectDataBase-FirstConnectionString %>" ProviderName="<%$ ConnectionStrings:EntityProjectDataBase-FirstConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
    </form>
</body>
</html>
