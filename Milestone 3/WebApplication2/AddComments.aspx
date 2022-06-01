<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddComments.aspx.cs" Inherits="WebApplication2.AddingComments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter Thesis Serial Number:</div>
        <asp:TextBox ID="serialnum" runat="server"></asp:TextBox>
        <br />
        Enter Defense Date:<br />
        <asp:TextBox ID="defdate" runat="server"></asp:TextBox>
        <br />
        
        Add Your Comments:<br />
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" Height="56px" Width="508px"></asp:TextBox>

        <br />
        <asp:Button ID="comments" runat="server" Text="Add Comment" OnClick="comments_Click" />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
        <br />
        </form>
</body>
</html>
