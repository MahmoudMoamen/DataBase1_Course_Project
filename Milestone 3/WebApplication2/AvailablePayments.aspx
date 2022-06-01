<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvailablePayments.aspx.cs" Inherits="WebApplication2.AvailablePayments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
     <style>
          Table1 {
            width: 300px;
            border-collapse : collapse; 
            position:center;
            margin:auto;
            border-block-color : blue ;
            border-block-width : initial ;
           
        }
        #Table1, .td {
            border: 3px dashed DarkBlue;
           
        }
        .td {
            padding: 15px; 
            text-align: center;
            background-color: #04AA6D;
            color: white;
            font-size: 150%;
            position:center;
            margin:auto;
            border-spacing : initial ;
            height :max-content;
           
           
        }
     </style>
   
    <title></title>
</head > 
<body>
    <form id="form1" runat="server">
    <asp:Table ID="Supervisor" runat="server"  CellPadding="5"
            CellSpacing="25" Height="100px" BorderWidth="10" BackColor =" White"
                        >
                <asp:TableHeaderRow
                    runat="server" 
                ForeColor="White"
                BackColor="#00008b"
                Font-Bold="true">
                    <asp:TableHeaderCell CssClass="id" Text="Payment_ID">

                

                    </asp:TableHeaderCell>
                 
                </asp:TableHeaderRow>
                    
            </asp:Table>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" style="width: 64px" />
    </form>
    </body>
</html>
