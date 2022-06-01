<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDefenseGrade.aspx.cs" Inherits="WebApplication2.AddDefenseGrade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Enter Thesis Serial Number:<br />
            <asp:TextBox ID="ThesisSerialNo" runat="server"></asp:TextBox><br />
            Specify Defense Date:<br />
            <asp:TextBox ID="dateofdef" runat="server"></asp:TextBox>
            <br />

            Enter Grade:<br />
            <asp:TextBox ID="Grade" runat="server"></asp:TextBox><br />

            <br />
            <asp:Button ID="Add" runat="server" OnClick="AddGrade" Text="Add Grade" />
            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
        </div>
        
        
        
        </form>
</body>
</html>
