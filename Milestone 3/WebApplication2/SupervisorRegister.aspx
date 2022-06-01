<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorRegister.aspx.cs" Inherits="WebApplication2.Supervisor_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 536px;
            width: 199px;
        }
    </style>
</head>
<body style="height: 34px; width: 191px; font-size: x-large; font-style: italic; text-decoration: underline; font-weight: 700">
    <form id="form1" runat="server">
        <div>
        <h5>First Name</h5>
        <asp:TextBox ID="SupFirstName" runat="server" Height="16px" style="margin-top: 0px" Width="146px"></asp:TextBox>
        <h5>Last Name</h5>
        <asp:TextBox ID="SupLastName" runat="server" Height="16px" Width="147px"></asp:TextBox>
        <h5>Password</h5>
        <asp:TextBox ID="SupPassword" runat="server" Width="139px"></asp:TextBox>
        <h5>Faculty</h5>
        <asp:TextBox ID="SupFaculty" runat="server"></asp:TextBox>
        <h5>Email</h5>
        <asp:TextBox ID="SupEmail" runat="server" Width="116px"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" Height="32px" style="margin-top: 27px" Text="Register" Width="148px" 
    onClick="SupervisorRegister" />
            <br />
            <asp:TextBox ID="Message" runat="server" Width="165px" BorderWidth="0" Enabled="false"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Home" OnClick="Button2_Click" Width="153px" />
            <br />
            <asp:Button ID="Button3" runat="server" Height="30px" Text="Click Here to Continue" Width="155px" Enabled="false" OnClick="Button3_Click" />
            <br />
            </div>
    </form>
</body>
</html>
