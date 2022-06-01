<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIssueInstallPayment.aspx.cs" Inherits="WebApplication2.AdminIssueInstallPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"
                Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"
                ></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="paymentID"></asp:Label>
            :<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            
            <br />
            
            <br />
            <asp:Button ID="Button1" runat="server" Text="Issue" OnClick="Button1_Click" />
            
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Available Paymnets" OnClick="Button2_Click" />
            
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Home" OnClick="Button3_Click" />
            
            </div>
    </form>
    <p>

    </p>
    <p>
        &nbsp;</p>
</body>
</html>
