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
    public partial class AdminListSup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string strcon = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand AdminListSup = new SqlCommand("AdminListSup", con);

            con.Open();

            SqlDataReader reader = AdminListSup.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {

                string ID = reader.GetValue(reader.GetOrdinal("id")).ToString();
                string email = reader.GetValue(reader.GetOrdinal("email")).ToString();
                string pass = reader.GetValue(reader.GetOrdinal("password")).ToString();
                string name = reader.GetValue(reader.GetOrdinal("name")).ToString();
                string fac = reader.GetValue(reader.GetOrdinal("faculty")).ToString();


                TableRow r = new TableRow();

                TableCell c1 = new TableCell();
                c1.Text = ID.ToString();
                c1.Font.Size = FontUnit.Large;

                TableCell c2 = new TableCell();
                c2.Text = email;
                c2.Font.Size = FontUnit.XLarge;

                TableCell c3 = new TableCell();
                c3.Text = pass;
                c3.Font.Size = FontUnit.XLarge;

                TableCell c4 = new TableCell();
                c4.Text = name;
                c4.Font.Size = FontUnit.XLarge;

                TableCell c5 = new TableCell();
                c5.Text = fac;
                c5.Font.Size = FontUnit.XLarge;

                r.Controls.Add(c1);
                r.Controls.Add(c2);
                r.Controls.Add(c3);
                r.Controls.Add(c4);
                r.Controls.Add(c5);

                Supervisor.Controls.Add(r);

            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}