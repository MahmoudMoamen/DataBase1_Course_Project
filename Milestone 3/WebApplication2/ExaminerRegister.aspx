<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerRegister.aspx.cs" Inherits="WebApplication2.Examiner_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name:<br />
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
            <br />
            <br />
            Email:<br />
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <br />
            <br />
            Field of Work:<br />
            <asp:TextBox ID="FieldOfWork" runat="server"></asp:TextBox>
            <br />
            <br />
            Nationality:<br />
            <asp:TextBox ID="Nationality" runat="server"></asp:TextBox>
            <br />
            <br />
            Password:<br />
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="RegisterButton" runat="server" OnClick="ExaminerRegister" Text="Register" />
            <br />
            <br />
            <asp:TextBox ID="Message" runat="server" Width="151px" BorderWidth="0"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Button ID="Continue" runat="server" Text="Continue" Enabled="false"/>
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
