using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class AdminViewAllTheses : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand AdminViewAllTheses = new SqlCommand("AdminViewAllTheses", con);

            con.Open();

            SqlDataReader reader = AdminViewAllTheses.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            while (reader.Read())
            {

                string sn = reader.GetValue(reader.GetOrdinal("serialNumber")).ToString();
                string field = reader.GetString(reader.GetOrdinal("field")).ToString();
                string type = reader.GetString(reader.GetOrdinal("type")).ToString();
                string title = reader.GetString(reader.GetOrdinal("title")).ToString();
                string sD = reader.GetDateTime(reader.GetOrdinal("startDate")).ToString();
                string eD = reader.GetDateTime(reader.GetOrdinal("endDate")).ToString();
                string dD = reader.GetDateTime(reader.GetOrdinal("defenseDate")).ToString();
                string years = reader.GetInt32(reader.GetOrdinal("years")).ToString();
                string grade = reader.GetDecimal(reader.GetOrdinal("grade")).ToString();
                string pID = reader.GetInt32(reader.GetOrdinal("payment_id")).ToString();
                string ne = reader.GetInt32(reader.GetOrdinal("noOfExtensions")).ToString();


                TableRow r = new TableRow();

                TableCell c1 = new TableCell();
                c1.Text = sn.ToString();
                c1.Font.Size = FontUnit.Large;
                
                TableCell c2 = new TableCell();
                c2.Text = field;
                c2.Font.Size = FontUnit.XLarge;
                
                TableCell c3 = new TableCell();
                c3.Text = type;
                c3.Font.Size = FontUnit.XLarge;
                
                TableCell c4 = new TableCell();
                c4.Text = title;
                c4.Font.Size = FontUnit.XLarge;

                TableCell c5 = new TableCell();
                c5.Text = sD.ToString();
                c5.Font.Size = FontUnit.XLarge;
             
                TableCell c6 = new TableCell();
                c6.Text = eD.ToString();
                c6.Font.Size = FontUnit.XLarge;
              
                TableCell c7 = new TableCell();
                c7.Text = dD.ToString();
                c7.Font.Size = FontUnit.XLarge;
                
                TableCell c8 = new TableCell();
                c8.Text = years.ToString();
                c8.Font.Size = FontUnit.XLarge;
               
                TableCell c9 = new TableCell();
                c9.Text = grade.ToString();
                c9.Font.Size = FontUnit.XLarge;
                
                TableCell c10 = new TableCell();
                c10.Text = pID.ToString();
                c10.Font.Size = FontUnit.XLarge;
                
                TableCell c11 = new TableCell();
                c11.Text = ne.ToString();
                c11.Font.Size = FontUnit.XLarge;
                

                r.Controls.Add(c1);
                r.Controls.Add(c2);
                r.Controls.Add(c3);
                r.Controls.Add(c4);
                r.Controls.Add(c5);
                r.Controls.Add(c6);
                r.Controls.Add(c7);
                r.Controls.Add(c8);
                r.Controls.Add(c9);
                r.Controls.Add(c10);
                r.Controls.Add(c11);


                Thesis.Controls.Add(r);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}