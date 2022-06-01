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
    public partial class EditPersonalInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateInfo(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["PostGradOfficee"].ToString();
            SqlConnection con = new SqlConnection(strcon);

            if (String.IsNullOrEmpty(updatedname.Text) || String.IsNullOrEmpty(updatedfield.Text))
                Response.Write("<script>alert('Please Enter All The Required Data');</script>");

            else
            {
                SqlCommand EditingPersonalInfo = new SqlCommand("editEProfile", con);
                EditingPersonalInfo.CommandType = CommandType.StoredProcedure;
                String ename = updatedname.Text;
                String fow = updatedfield.Text;
                //int yourid = Session[""];
                HttpCookie aCookie = Request.Cookies["loginCookie1"];
                String sidstr = Server.HtmlEncode(aCookie.Value);
                int sidint = int.Parse(sidstr);

                EditingPersonalInfo.Parameters.Add(new SqlParameter("@id", sidint));
                EditingPersonalInfo.Parameters.Add(new SqlParameter("@name", updatedname));
                EditingPersonalInfo.Parameters.Add(new SqlParameter("@fieldofwork", updatedfield));
                Response.Write("<script>alert('Editted Successfully');</script>");
                con.Open();
                EditingPersonalInfo.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorView.aspx");
        }
    }
}