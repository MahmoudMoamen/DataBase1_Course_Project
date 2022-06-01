<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminListSup.aspx.cs" Inherits="WebApplication2.AdminListSup" %>


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
                    <asp:TableHeaderCell CssClass="id" Text="ID">

                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="e" Text="Email">

                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="pass" Text="Password">

                    </asp:TableHeaderCell>
                  <asp:TableHeaderCell CssClass="n" Text="Name">

                    </asp:TableHeaderCell>
                     <asp:TableHeaderCell CssClass="f" Text="Faculty">

                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                    
            </asp:Table>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Home" OnClick="Button2_Click1" />
        </p>
    </form>
    </body>
</html>