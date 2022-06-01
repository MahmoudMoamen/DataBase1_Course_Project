<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="WebApplication2.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="ViewProfile" runat="server" Text="View My Profile" Width="312px" OnClick="ViewProfile_Click"/>
            <br />
            <br />
            <asp:Button ID="ListingThesis" runat="server" Text="List All My Theses" onClick="ListingThesis_Click" Width="314px"/>
            <br />
            <br />
            <asp:Button ID="ViewingCourses" runat="server" Text="View My Courses info and Grades" Width="314px" OnClick="ViewingCourses_Click"/>
            <br />
            <br />
            <asp:Button ID="AddProgressReport" runat="server" Text="Add & Fill Progress Report on My Ongoing Thesis" Width="313px" OnClick="AddProgressReport_Click"/>
            <br />
            <br />
            <asp:Button ID="Add" runat="server" Text="Add and Link Publication to Ongoing Thesis" Width="311px" OnClick="Add_Click"/>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Login Page" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
