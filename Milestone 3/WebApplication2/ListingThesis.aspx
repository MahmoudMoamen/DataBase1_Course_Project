<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListingThesis.aspx.cs" Inherits="WebApplication2.ListingThesis" %>

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
    <asp:Table ID="Theses" runat="server"  CellPadding="5"
            CellSpacing="25" Height="100px" BorderWidth="10" BackColor =" White"
                        >
                <asp:TableHeaderRow
                    runat="server" 
                ForeColor="White"
                BackColor="#00008b"
                Font-Bold="true">
                    <asp:TableHeaderCell CssClass="id" Text="Student_ID">

                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="field" Text="Field">

                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="type" Text="Type">

                    </asp:TableHeaderCell>
                  <asp:TableHeaderCell CssClass="title" Text="Title">

                    </asp:TableHeaderCell>
                      <asp:TableHeaderCell CssClass="startDate" Text="StartDate">

                    </asp:TableHeaderCell>
                  <asp:TableHeaderCell CssClass="endDate" Text="EndDate">

                    </asp:TableHeaderCell>
                  <asp:TableHeaderCell CssClass="defenseDate" Text="DefenseDate">

                    </asp:TableHeaderCell>
                      <asp:TableHeaderCell CssClass="years" Text="Years">

                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="grade" Text="Grade">

                        </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="paymentId" Text="Payment ID">

                        </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="noExtensions" Text="Number Of Extensions">

                    </asp:TableHeaderCell>
               
                         
                              
                                </asp:TableHeaderRow>
                    
            </asp:Table>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Student Home" OnClick="Button1_Click" />
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
        <p>
            &nbsp;</p>
    </form>
    </body>
</html>
