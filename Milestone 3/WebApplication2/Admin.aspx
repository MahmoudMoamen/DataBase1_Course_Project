<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication2.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Sup" runat="server" OnClick="Button1_Click" Text="List All Supervisor" Height="77px" Width="350px" />
        &nbsp;&nbsp;<br />
            &nbsp;<br />
&nbsp;<asp:Button ID="Button1" runat="server" Text="List all Thesis" OnClick="Button1_Click1" Height="77px" Width="350px" />

        &nbsp;&nbsp;<br />
            &nbsp;<br />
&nbsp;<asp:Button ID="Button2" runat="server" Text="View Count of on going Thesis" OnClick="Button2_Click" Height="77px" Width="350px" />

        &nbsp;&nbsp;<br />
            <br />
            &nbsp;<asp:Button ID="Button3" runat="server" Text="Issue a thesis payment " OnClick="Button3_Click" Height="77px" Width="350px" />

        &nbsp;&nbsp;&nbsp;<br />
            <br />
&nbsp;<asp:Button ID="Button4" runat="server" Text="Issue a Thesis Installment" OnClick="Button4_Click" Height="77px" Width="350px" />

        &nbsp;&nbsp;<br />
            <br />
            &nbsp;<asp:Button ID="Button5" runat="server" Text="Update Thesis Extention" OnClick="Button5_Click" Height="77px" Width="350px" />

            <br />
            <br />
&nbsp;</div>
    </form>
</body>
</html>

