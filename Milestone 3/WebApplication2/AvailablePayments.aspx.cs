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
    public partial class AvailablePayments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string strcon = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand AvailablePayments = new SqlCommand("AvailablePayments", con);

            con.Open();

            SqlDataReader reader = AvailablePayments.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {

                int ID = reader.GetInt32(reader.GetOrdinal("id"));

                TableRow r = new TableRow();

                TableCell c1 = new TableCell();
                c1.Text = ID.ToString();
                c1.Font.Size = FontUnit.Large;

                r.Controls.Add(c1);

                Supervisor.Controls.Add(r);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminIssueInstallPayment.aspx");
        }
    }
}