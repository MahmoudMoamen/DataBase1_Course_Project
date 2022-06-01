<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="General.aspx.cs" Inherits="WebApplication2.General" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Please Enter your Title for Registeration<br />
        <asp:Button ID="Student" runat="server" Text="Student" OnClick="Student_Click" />
        <asp:Button ID="Supervisor" runat="server" Text="Supervisor" OnClick="Supervisor_Click"  />
        <asp:Button ID="Examiner" runat="server" Text="Examiner" OnClick="Examiner_Click"  />
        <br />
        <br />
        <asp:LinkButton ID="Login" runat="server" OnClick="Login_Click">If you are a user CLICK HERE to Login</asp:LinkButton>
    </form>
</body>
</html>
