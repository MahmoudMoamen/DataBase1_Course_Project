using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("AdminListSup.aspx");


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewAllTheses.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewAllOnGoingTheses.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminIssueThesesPayment.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminIssueInstallPayment.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateExtension.aspx");
        }
    }
}
        
/*
 string strcon = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand view1 = new SqlCommand("Gucianviewthesis", con);
            view1.CommandType = CommandType.StoredProcedure;
            String x1 = (Session["user"]).ToString();
            view1.Parameters.Add(new SqlParameter("@id", x1));
            SqlParameter suc = view1.Parameters.Add("@suc", SqlDbType.Int);
            suc.Direction = ParameterDirection.Output;

            con.Open();

            SqlDataReader rdr1 = view1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (rdr1.Read())
            {

                int s = rdr1.GetInt32(rdr1.GetOrdinal("serialnumber"));
                String f = rdr1.GetString(rdr1.GetOrdinal("field"));
                String T = rdr1.GetString(rdr1.GetOrdinal("type"));
                String t = rdr1.GetString(rdr1.GetOrdinal("title"));
                DateTime SD = rdr1.GetDateTime(rdr1.GetOrdinal("startDate"));
                DateTime SE = rdr1.GetDateTime(rdr1.GetOrdinal("endDate"));
                DateTime DD = rdr1.GetDateTime(rdr1.GetOrdinal("defenceDate"));
                int y = rdr1.GetInt32(rdr1.GetOrdinal("years"));
                decimal G = rdr1.GetDecimal(rdr1.GetOrdinal("grade"));
                int p = rdr1.GetInt32(rdr1.GetOrdinal("payment_id"));
                int N = rdr1.GetInt32(rdr1.GetOrdinal("noExtension"));

                
                TableRow x2 = new TableRow();
                
                TableCell x3 = new TableCell();
                x3.Text = s.ToString();
                x3.Font.Size = FontUnit.XLarge;
                x3.Font.Bold = true;
                
                TableCell x4 = new TableCell();
                x4.Text = f;
                x4.Font.Size = FontUnit.XLarge;
                x4.Font.Bold = true;
                TableCell x5 = new TableCell();
                x5.Text = T;
                x5.Font.Size = FontUnit.XLarge;
                x5.Font.Bold = true;
                TableCell x6 = new TableCell();
                x6.Text = t;
                x6.Font.Size = FontUnit.XLarge;
                x6.Font.Bold = true;
                TableCell x7 = new TableCell();
                x7.Text = SD.ToString();
                x7.Font.Size = FontUnit.XLarge;
                x7.Font.Bold = true;
                TableCell x8 = new TableCell();
                x8.Text = SE.ToString();
                x8.Font.Size = FontUnit.XLarge;
                x8.Font.Bold = true;
                TableCell x9 = new TableCell();
                x9.Text = DD.ToString();
                x9.Font.Size = FontUnit.XLarge;
                x9.Font.Bold = true;
                TableCell x10 = new TableCell();
                x10.Text = y.ToString();
                x10.Font.Size = FontUnit.XLarge;
                x10.Font.Bold = true;
                TableCell x11 = new TableCell();
                x11.Text = G.ToString();
                x11.Font.Size = FontUnit.XLarge;
                x11.Font.Bold = true;
                TableCell x12 = new TableCell();
                x12.Text = p.ToString();
                x12.Font.Size = FontUnit.XLarge;
                x12.Font.Bold = true;
                TableCell x13 = new TableCell();
                x13.Text = N.ToString();
                x13.Font.Size = FontUnit.XLarge;
                x13.Font.Bold = true;

                x2.Controls.Add(x3);
                x2.Controls.Add(x4);
                x2.Controls.Add(x5);
                x2.Controls.Add(x6);
                x2.Controls.Add(x7);
                x2.Controls.Add(x8);
                x2.Controls.Add(x9);
                x2.Controls.Add(x10);
                x2.Controls.Add(x11);
                x2.Controls.Add(x12);
                x2.Controls.Add(x13);


                Table1.Controls.Add(x2);
            }
        }
*/