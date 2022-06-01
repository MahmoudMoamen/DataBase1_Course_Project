<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAndLinkPublicationToOngoingThesis.aspx.cs" Inherits="WebApplication2.AddAndLinkPublicationToOngoingThesis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Publication Title:<br />
            <asp:TextBox ID="Title" runat="server"></asp:TextBox>
            <br />
            <br />
            Publication Date:<br />
            <asp:TextBox ID="Date" Text=<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>  TextMode="Date" runat="server"></asp:TextBox>
            <br />
            <br />
            Host:<br />
            <asp:TextBox ID="Host" runat="server"></asp:TextBox>
            <br />
            <br />
            Place:<br />
            <asp:TextBox ID="Place" runat="server"></asp:TextBox>
            <br />
            <br />
            Accepted:<br />
            <asp:CheckBox ID="CheckBox" runat="server"/>
            <br />
            <br />
            <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click"/>
            <br />
            <br />
            <asp:TextBox ID="MessageBox" runat="server" BorderWidth="0" Enabled="false" style="margin-right: 2px" Width="230px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="LinkButton" runat="server" Text="Link" Enabled="false" OnClick="LinkButton_Click"/>
            <br />
            <br />
            <asp:TextBox ID="Message2" runat="server" BorderWidth="0" Height="17px" Width="244px" Enabled="false"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Student Home" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
