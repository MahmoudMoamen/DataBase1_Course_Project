<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorView.aspx.cs" Inherits="WebApplication2.SupervisorView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Button ID="Button1" runat="server" Text="Edit My Info" Width="245px" 
                Height="62px" OnClick="Button1_Click" /> 
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="List of Attended Defenses" 
                Width="245px" 
                Height="62px" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Add My Comments" Width="245px" 
                Height="62px" OnClick="Button3_Click"/>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Add Grades"  Width="245px" 
                Height="62px" OnClick="Button4_Click"/>


            
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" Text="Search For Thesis" Width="245px" 
                Height="62px" OnClick="Button5_Click"/>


            
        </div>
    </form>
</body>
</html>
