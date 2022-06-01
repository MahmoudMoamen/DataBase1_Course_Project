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
    public partial class ViewAttended : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["PostGradOfficee"].ToString();
            SqlConnection con = new SqlConnection(strcon);

           
            SqlCommand ViewAttendedproc = new SqlCommand("ViewAttended", con);
            ViewAttendedproc.CommandType = CommandType.StoredProcedure;

            
            con.Open();
            SqlDataReader rdr1 = ViewAttendedproc.ExecuteReader(CommandBehavior.CloseConnection);
            
            while (rdr1.Read())
            {
                

                //int idex = Session[""];
               
                string Tt = rdr1.GetString(rdr1.GetOrdinal("title"));
                string sn = rdr1.GetString(rdr1.GetOrdinal("firstName"));
                string Supn = rdr1.GetString(rdr1.GetOrdinal("name"));
               
                TableRow r = new TableRow();

                TableCell c1 = new TableCell();
                c1.Text = Tt;
                c1.Font.Size = FontUnit.Large;

                TableCell c2 = new TableCell();
                c2.Text = sn;
                c2.Font.Size = FontUnit.XLarge;

                TableCell c3 = new TableCell();
                c3.Text = Supn;
                c3.Font.Size = FontUnit.XLarge;

               
                r.Controls.Add(c1);
                r.Controls.Add(c2);
                r.Controls.Add(c3);
                

                Attended.Controls.Add(r);


                //ViewAttendedproc.Parameters.Add(new SqlParameter("@examinerid", Idex));

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorView.aspx");
        }

       
    }
}