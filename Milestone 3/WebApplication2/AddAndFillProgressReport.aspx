<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAndFillProgressReport.aspx.cs" Inherits="WebApplication2.AddAndFillProgressReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Thesis Serial Number:<br />
            <asp:TextBox ID="TSN" runat="server"></asp:TextBox>
            <br />
            <br />
            Progress Report Date:<br />
            <asp:TextBox ID="PRD" runat="server" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
            <br />
            <br />
            Progress Report Number:<br />
            <asp:TextBox ID="PRN" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Add" runat="server" Text="Add" OnClick="Add_Click"/>
            <br />
            <br />
            <asp:TextBox ID="Message" runat="server" BorderWidth="0" Enabled="false" Width="250px"></asp:TextBox>
            <br />
            <br />
            State:<br />
            <asp:TextBox ID="State" runat="server" Enabled="false"></asp:TextBox>
            <br />
            <br />
            Description:<br />
            <asp:TextBox ID="description" runat="server" Enabled ="false"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Fill" runat="server" Text="Fill" Enabled="false" OnClick="Fill_Click"/>
            <br />
            <br />
            <asp:TextBox ID="Message2" runat="server" Width="215px" BorderWidth="0" Enabled="false"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Student Home" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
