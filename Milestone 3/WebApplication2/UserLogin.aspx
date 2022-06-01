<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="WebApplication2.User_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email:<br />
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <br />
            <br />
            Password:<br />
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Login" runat="server" Text="Login" onClick="UserLogin_Click"/>
            <br />
            <asp:TextBox ID="MessageBox" runat="server" BorderWidth="0" Enabled="false" Width="269px" Height="23px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ContinueButton" runat="server" Text="Click Here to Continue" Enabled= "false" OnClick="UserLoginRedirection"/>
        </div>
    </form>
</body>
</html>
