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
    public partial class availableThesis2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string strcon = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand availableThesis2 = new SqlCommand("availableThesis", con);

            con.Open();

            SqlDataReader reader = availableThesis2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {

                int ID = reader.GetInt32(reader.GetOrdinal("serialNumber"));

                TableRow r = new TableRow();

                TableCell c1 = new TableCell();
                c1.Text = ID.ToString();
                c1.Font.Size = FontUnit.Large;

                r.Controls.Add(c1);

                Supervisor.Controls.Add(r);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateExtension.aspx");
        }
    }
}