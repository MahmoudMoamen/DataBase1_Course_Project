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
    public partial class AddDefenseGrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected TextBox GetThesisSerialNo()
        {
            return ThesisSerialNo;
        }

       

        protected void AddGrade(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
            SqlConnection con = new SqlConnection(strcon);

            if (String.IsNullOrEmpty(ThesisSerialNo.Text) || String.IsNullOrEmpty(dateofdef.Text) || String.IsNullOrEmpty(Grade.Text))
                Response.Write("<script>alert('Please Enter All The Required Data');</script>");
            else
            {
                SqlCommand AddingDefenseGrade = new SqlCommand("AddDefenseGrade", con);
                AddingDefenseGrade.CommandType = CommandType.StoredProcedure;
                int serialno = Int16.Parse(ThesisSerialNo.Text);
                DateTime date = DateTime.Parse(dateofdef.Text);
                decimal grade = decimal.Parse(Grade.Text);

                
                AddingDefenseGrade.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialno));
                AddingDefenseGrade.Parameters.Add(new SqlParameter("@DefenseDate", date));
                AddingDefenseGrade.Parameters.Add(new SqlParameter("@grade", grade));
                Response.Write("<script>alert('Added Successfully');</script>");
                con.Open();
                AddingDefenseGrade.ExecuteNonQuery();
                con.Close();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorView.aspx");
        }
    }
        }
    
