<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAttended.aspx.cs" Inherits="WebApplication2.ViewAttended" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
    <title></title>
  
</head > 
<body>

 <form id="form1" runat="server">
    <asp:Table ID="Attended" runat="server"  CellPadding="5"
            CellSpacing="25" Height="100px" BorderWidth="10" BackColor =" White"
                        >
                <asp:TableHeaderRow
                    runat="server" 
                ForeColor="White"
                BackColor="#00008b"
                Font-Bold="true">
                    <asp:TableHeaderCell CssClass="Tt" Text="Thesis Title">

                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="Sn" Text="Student Name">

                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="Supn" Text="Supervisor Name">

                    </asp:TableHeaderCell>
               
                         
                              
                                </asp:TableHeaderRow>
                    
            </asp:Table>
        
     <p>
            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
     </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
      <p>
            &nbsp;</p>
      <p>
            &nbsp;</p>
      <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        
       
    </form>
    </body>
</html>