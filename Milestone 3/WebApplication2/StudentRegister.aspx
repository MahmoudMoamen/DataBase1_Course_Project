<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegister.aspx.cs" Inherits="WebApplication2.Student_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please Enter your Details<br />
            <br />
            First Name:<br />
            <asp:TextBox ID="FirstName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <br />
            Last Name:<br />
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            <br />
            Password:</div>
        <asp:TextBox ID="Password" runat="server"></asp:TextBox>
        <br />
        Faculty:<br />
        <asp:TextBox ID="Faculty" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:RadioButtonList ID="RadioButtonList" runat="server" Height="83px" name="Checking" Width="127px">
            <asp:ListItem Value="true">Gucian</asp:ListItem>
            <asp:ListItem Value="false">Non-Gucian</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        Email:<br />
        <asp:TextBox ID="Email" runat="server" Width="262px"></asp:TextBox>
        <br />
        Address:<br />
        <asp:TextBox ID="Address" runat="server" Width="258px"></asp:TextBox>
        <br />
        <asp:Button ID="Register" runat="server" Text="Register" OnClick="StudentRegister" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Click Here To Login" Enabled="false" OnClick="Button2_Click"/>
        <br />
        <br />
        <asp:TextBox ID="Message" runat="server" BorderWidth="0" Enabled="false" Width="273px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
    </form>
</body>
</html>
