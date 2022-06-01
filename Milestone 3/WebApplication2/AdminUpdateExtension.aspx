<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUpdateExtension.aspx.cs" Inherits="WebApplication2.AdminUpdateExtension" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Thesis Serial Number"></asp:Label>
        :<div>
            <asp:TextBox ID="TextBox1" runat="server" Width="203px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Available Thesis" OnClick="Button2_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Home" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
