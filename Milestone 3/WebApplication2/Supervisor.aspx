<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supervisor.aspx.cs" Inherits="WebApplication2.Supervisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID</div>
        <asp:Button ID="Button1" runat="server" Text="Student List" OnClick="Button1_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" style="margin-left: 0px" Text="StudentPublication" Width="139px" OnClick="Button2_Click" />
        <br />
        &nbsp; ThesisSerialNo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DefenseDate&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DefenseLocation&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Type<br />
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBox15" runat="server" OnTextChanged="TextBox15_TextChanged"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Add Defense" OnClick="Button3_Click" />
        <br />
        <p>
            &nbsp;</p>
        <p>
            ThesisSerialNo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DefenseDate</p>
        <p>
            <asp:TextBox ID="TextBox7" runat="server" OnTextChanged="TextBox7_TextChanged"></asp:TextBox>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </p>
        <p>
            ExaminerName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Password</p>
        <p>
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </p>
        <p>
            National&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fieldOfWork</p>
        <p>
            <asp:TextBox ID="TextBox8" runat="server" OnTextChanged="TextBox8_TextChanged"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button4" runat="server" Text="AddExaminer" OnClick="Button4_Click" />
        </p>
        <p>
            &nbsp;thesisSerialNo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; progressReportNo&nbsp;&nbsp;&nbsp;&nbsp; evaluation</p>
        <p>
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Evaluate" />
        </p>
        <p>
            ThesisSerialNo</p>
        <p>
            <asp:TextBox ID="TextBox14" runat="server" OnTextChanged="TextBox14_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button6" runat="server" Text="Cancel Thesis" OnClick="Button6_Click" />
        </p>
    </form>
</body>
</html>
