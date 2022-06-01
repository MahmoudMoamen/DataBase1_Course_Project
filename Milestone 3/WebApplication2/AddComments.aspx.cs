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
    public partial class AddingComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void comment(object sender, EventArgs e)
        {
            
        }

        protected void comments_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
            SqlConnection con = new SqlConnection(strcon);

            if (String.IsNullOrEmpty(serialnum.Text) || String.IsNullOrEmpty(defdate.Text) || String.IsNullOrEmpty(comments.Text))
                Response.Write("<script>alert('Please Enter All The Required Data');</script>");
            else
            {
                int serialno = Int16.Parse(serialnum.Text);
                DateTime dod = DateTime.Parse(defdate.Text);
                String c = comments.Text;

                SqlCommand AddingComments = new SqlCommand("AddCommentsGrade", con);
                AddingComments.CommandType = CommandType.StoredProcedure;

                AddingComments.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialno));
                AddingComments.Parameters.Add(new SqlParameter("@DefenseDate", dod));
                AddingComments.Parameters.Add(new SqlParameter("@comments", c));
                Response.Write("<script>alert('Added Successfully');</script>");

                con.Open();
                AddingComments.ExecuteNonQuery();
                con.Close();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorView.aspx");
        }
    }
}