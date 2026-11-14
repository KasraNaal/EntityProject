<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="EndPoint.Site.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@6.0.0-alpha.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-B/GM4XqrwHnWXNOWMbloTmrYXZg10cakYGmpfsR/bbzQ6JAJI4ihuyADKLnBgrCe" crossorigin="anonymous">
    <script type="module" src="https://cdn.jsdelivr.net/npm/bootstrap@6.0.0-alpha.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-1a/pXj49ZQ1aHEmrJ+gMw1otqoVsYwlEnlD8mIfY2TV03r20Y0CN7uqx1tQogjPL" crossorigin="anonymous"></script>
    <link href="Styles/Style.css" rel="stylesheet" />
    <title>Add User</title>
</head>

<body>
    <form id="form1" runat="server">
        <div style="width: 450px; margin: 40px auto; text-align: left;">

            <section class="card" style="max-width: 320px">
                <div class="card-body">

                    <div style="text-align: center">
                        <h4 class="card-title">Add User</h4>

                    </div>


                    <asp:Label ID="lblFirstName" runat="server" Text="FirstName: "></asp:Label>
                    <asp:TextBox ID="txtbFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="fvFirstName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtbFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="evFirstName" runat="server" ErrorMessage="Enter a-z or A-Z" ValidationExpression="^[a-zA-Z]+$" ControlToValidate="txtbFirstName" ForeColor="Red" Display="Dynamic" EnableClientScript="false"></asp:RegularExpressionValidator>
                    

                    <asp:Label ID="lblLastName" runat="server" Text="LastName: "></asp:Label>
                    <asp:TextBox ID="txtbLastName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="fvLastName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtbLastName" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="evLastName" runat="server" ErrorMessage="Enter a-z or A-Z" ValidationExpression="^[a-zA-Z]+$" ControlToValidate="txtbLastName" ForeColor="Red" Display="Dynamic" EnableClientScript="false"></asp:RegularExpressionValidator>


                    <asp:Label ID="lblUserName" runat="server" Text="UserName: "></asp:Label>
                    <asp:TextBox ID="txtbUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="fvUserName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtbUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="evUserName" runat="server" ErrorMessage="a-z, A-Z and (@,#,$) are allowed" ValidationExpression="^[a-zA-Z@#$\d]+$" ControlToValidate="txtbUserName" ForeColor="Red" Display="Dynamic" EnableClientScript="false"></asp:RegularExpressionValidator>


                    <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>


                    <div style="display: flex; align-items: center; gap: 5px">
                        <asp:TextBox ID="txtbPassword" runat="server" ValidationGroup="RegisterGroup" TextMode="Password" Style="flex: 1; min-width: 0;"></asp:TextBox>
                        <button type="button" onclick="togglePassword('<%= txtbPassword.ClientID %>', this)"
                            style="width: 34px; height: 34px; padding: 0; display: flex; align-items: center; justify-content: center; cursor: pointer; border: 1px solid #666; border-radius: 4px; background-color: #2c2c2c; color: white;">
                            <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path>
                                <circle cx="12" cy="12" r="3"></circle>
                            </svg>
                        </button>
                    </div>

                    <asp:RequiredFieldValidator ID="fvPassword" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtbPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="evPassword" runat="server" ErrorMessage="lower, upper, number and (@,#,$) must be entered" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$])[a-zA-Z\d@#$]+$" ControlToValidate="txtbPassword" ForeColor="Red" Display="Dynamic" EnableClientScript="false"></asp:RegularExpressionValidator>



                    <asp:Label ID="lblConfirmPassword" runat="server" Style="direction: ltr" Text="Confirm Password: "></asp:Label>

                    <div style="display: flex; align-items: center; gap: 5px; width: 100%;">
                        <asp:TextBox ID="txtbConfirmPassword" runat="server" ValidationGroup="RegisterGroup" TextMode="Password" style="flex: 1; min-width: 0;"></asp:TextBox>
                        <button type="button" onclick="togglePassword('<%= txtbConfirmPassword.ClientID %>', this)"
                            style="width: 34px; height: 34px; padding: 0; display: flex; align-items: center; justify-content: center; cursor: pointer; border: 1px solid #666; border-radius: 4px; background-color: #2c2c2c; color: white;">
                            <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path>
                                <circle cx="12" cy="12" r="3"></circle>
                            </svg>
                        </button>
                    </div>

                    <asp:RequiredFieldValidator ID="fvConfirmPassword" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtbConfirmPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" ErrorMessage="not matched" ControlToValidate="txtbConfirmPassword" ControlToCompare="txtbPassword" Operator="Equal" Type="String" ForeColor="Red" Display="Dynamic" EnableClientScript="false"></asp:CompareValidator>

                    <div style="text-align: center;">
                        <asp:Button ID="btnSubmitUser" runat="server" Text="Submit" ValidationGroup="RegisterGroup" class="btn-text theme-primary" />
                    </div>


                    <asp:Label ID="lblMessege" runat="server" ValidationGroup="RegisterGroup"></asp:Label>


                </div>
            </section>



        </div>
    </form>

    <script>
    function togglePassword(inputId, btn) {
        var input = document.getElementById(inputId);
        
        var eyeOpen = '<svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx="12" cy="12" r="3"></circle></svg>';
        
        var eyeClosed = '<svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M17.94 17.94A10.07 10.07 0 0 1 12 20c-7 0-11-8-11-8a18.45 18.45 0 0 1 5.06-5.94M9.9 4.24A9.12 9.12 0 0 1 12 4c7 0 11 8 11 8a18.5 18.5 0 0 1-2.16 3.19m-6.72-1.07a3 3 0 1 1-4.24-4.24"></path><line x1="1" y1="1" x2="23" y2="23"></line></svg>';

        if (input.type === "password") {
            input.type = "text";
            btn.innerHTML = eyeClosed;
        } else {
            input.type = "password";
            btn.innerHTML = eyeOpen;
        }
    }
    </script>

</body>
</html>
