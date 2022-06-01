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
    public partial class AdminViewAllOnGoingTheses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

            String strcon = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand AdminViewAllOnGoingTheses = new SqlCommand("AdminViewOnGoingTheses", con);
            AdminViewAllOnGoingTheses.CommandType=CommandType.StoredProcedure;
            SqlParameter count = AdminViewAllOnGoingTheses.Parameters.Add("@thesesCount", SqlDbType.Int);
            count.Direction = System.Data.ParameterDirection.Output;
            
            
            con.Open();
            AdminViewAllOnGoingTheses.ExecuteNonQuery();
            con.Close();
            Label1.Text = count.Value.ToString();













        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}