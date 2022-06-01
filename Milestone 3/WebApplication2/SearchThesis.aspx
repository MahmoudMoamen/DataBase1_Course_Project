<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchThesis.aspx.cs" Inherits="WebApplication2.SearchThesis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter Thesis Title:<br />
            <asp:TextBox ID="thesistitle" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="searching" runat="server" Text="Search" 
                OnClick="searching_Click" />
            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
            <br />
            

    <asp:Table ID="Thesis" runat="server"  CellPadding="5"
            CellSpacing="25" Height="100px" BorderWidth="10" BackColor =" White"
                        >
                <asp:TableHeaderRow
                    runat="server" 
                ForeColor="White"
                BackColor="#00008b"
                Font-Bold="true">
                    <asp:TableHeaderCell CssClass="sN" Text="SerialNumber">

                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="field" Text="Field">

                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="type" Text="Type">

                    </asp:TableHeaderCell>
                  <asp:TableHeaderCell CssClass="title" Text="Title">

                    </asp:TableHeaderCell>
                      <asp:TableHeaderCell CssClass="sD" Text="startDate">

                    </asp:TableHeaderCell>
                  <asp:TableHeaderCell CssClass="eD" Text="endDate">

                    </asp:TableHeaderCell>
                  <asp:TableHeaderCell CssClass="dD" Text="defenceDate">

                    </asp:TableHeaderCell>
                      <asp:TableHeaderCell CssClass="Year" Text="Years">

                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="grade" Text="Grade">

                    </asp:TableHeaderCell>
                      <asp:TableHeaderCell CssClass="pid" Text="payment_ID">

                    </asp:TableHeaderCell>
                      <asp:TableHeaderCell CssClass="ne" Text="Number_of_Extensions">

                    </asp:TableHeaderCell>
               
                         
                              
                                </asp:TableHeaderRow>
                    
            </asp:Table>
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
        <p>
            &nbsp;</p>
                 </div>

    </form>
    </body>
</html>
  
