<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPersonalInfo.aspx.cs" Inherits="WebApplication2.EditPersonalInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Enter New Name:<br />
            <asp:TextBox ID="updatedname" runat="server" Width="230px"></asp:TextBox>
            <br />
            Enter New Field Of Work:<br />
            <asp:TextBox ID="updatedfield" runat="server" Width="228px"></asp:TextBox>

            <br />
            <br />
            <asp:Button ID="updateinfo" runat="server" Text="Update" OnClick="UpdateInfo" style="height: 29px" />

            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />

        </div>
    </form>
</body>
</html>
