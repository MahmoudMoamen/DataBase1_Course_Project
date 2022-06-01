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
    public partial class Supervisor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("AddStudent.aspx");
        }


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            int thesis = int.Parse(TextBox1.Text.ToString());
            string progress = TextBox12.Text.ToString();
            string eval = TextBox13.Text.ToString();
            int x = int.Parse(eval);


            SqlCommand loginProc = new SqlCommand("EvaluateProgressReport", conn);
            loginProc.CommandType = CommandType.StoredProcedure;

            loginProc.Parameters.Add(new SqlParameter("@thesisSerialNo", SqlDbType.Int)).Value = thesis;
            loginProc.Parameters.Add(new SqlParameter("@progressReportNo", SqlDbType.Int)).Value = progress;
            loginProc.Parameters.Add(new SqlParameter("@evaluation", SqlDbType.Int)).Value = eval;


            conn.Open();
            if (x > 0 && x < 3)
                loginProc.ExecuteNonQuery();
            conn.Close();
        }





        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            int thesis = int.Parse(TextBox1.Text.ToString());
            string defense = TextBox6.Text.ToString();
            string examiner = TextBox9.Text.ToString();
            string password = TextBox5.Text.ToString();
            string national = TextBox8.Text.ToString();
            string field = TextBox4.Text.ToString();


            SqlCommand loginProc = new SqlCommand("AddExaminer", conn);
            loginProc.CommandType = CommandType.StoredProcedure;

            loginProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = thesis;
            loginProc.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.DateTime)).Value = defense;
            loginProc.Parameters.Add(new SqlParameter("@ExaminerName", SqlDbType.VarChar)).Value = examiner;
            loginProc.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = password;
            loginProc.Parameters.Add(new SqlParameter("@National", SqlDbType.Bit)).Value = national;
            loginProc.Parameters.Add(new SqlParameter("@fieldOfWork", SqlDbType.VarChar)).Value = field;





            conn.Open();
            loginProc.ExecuteNonQuery();
            conn.Close();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            string thesis = TextBox14.Text.ToString();



            SqlCommand loginProc = new SqlCommand("CancelThesis", conn);
            loginProc.CommandType = CommandType.StoredProcedure;

            loginProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = thesis;


            conn.Open();
            loginProc.ExecuteNonQuery();
            conn.Close();
        }

        protected void TextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            int thesis = int.Parse(TextBox1.Text.ToString());
            DateTime DefenseDate = DateTime.Parse(TextBox2.Text.ToString());
            string DefenseLocation = TextBox3.Text.ToString();
            string type = TextBox15.Text.ToString();

            if (type == "gucian")
            {
                SqlCommand loginProc = new SqlCommand("AddDefenseGucian", conn);
                loginProc.CommandType = CommandType.StoredProcedure;

                loginProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = thesis;
                loginProc.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.DateTime)).Value = DefenseDate;
                loginProc.Parameters.Add(new SqlParameter("@DefenseLocation", SqlDbType.VarChar)).Value = DefenseLocation;



                conn.Open();
                loginProc.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                SqlCommand loginProc = new SqlCommand("AddDefenseNonGucian", conn);
                loginProc.CommandType = CommandType.StoredProcedure;

                loginProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = thesis;
                loginProc.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.DateTime)).Value = DefenseDate;
                loginProc.Parameters.Add(new SqlParameter("@DefenseLocation", SqlDbType.VarChar)).Value = DefenseLocation;

                conn.Open();
                loginProc.ExecuteNonQuery();
                conn.Close();
            }

        }

        protected void TextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPublication.aspx");
            Session["ID"] = TextBox16.Text;


        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}