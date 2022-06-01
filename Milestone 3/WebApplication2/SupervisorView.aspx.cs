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
    public partial class SupervisorView : System.Web.UI.Page
       
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["PostGradOfficee"].ToString();
            SqlConnection con = new SqlConnection(strcon);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditPersonalInfo.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAttended.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddComments.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDefenseGrade.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchThesis.aspx");
        }
    }
}