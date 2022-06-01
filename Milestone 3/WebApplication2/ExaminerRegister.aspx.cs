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
    public partial class Examiner_Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExaminerRegister (object sender, EventArgs e)
        {
            try
            {
            string connectionString = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            String name = Name.Text;
            String fieldofwork = FieldOfWork.Text;
            String nationality = Nationality.Text;
            String password = Password.Text;
            String email = Email.Text;

            if (name.Equals("") || fieldofwork.Equals("") || nationality.Equals("") || password.Equals("") || email.Equals(""))
                    throw new ArgumentNullException();

            else{
                    SqlCommand Reg = new SqlCommand("ExaminerRegister", conn);
            Reg.CommandType = System.Data.CommandType.StoredProcedure;
            Reg.Parameters.Add(new SqlParameter("@ExaminerName", name));
            Reg.Parameters.Add(new SqlParameter("@Password", password));
            Reg.Parameters.Add(new SqlParameter("@FieldOfWork", fieldofwork));
            Reg.Parameters.Add(new SqlParameter("@email", email));
            
            if (nationality.ToLower().Equals("egypt"))
            {
                Reg.Parameters.Add(new SqlParameter("@Nationality", '1'));
            }
            else
                Reg.Parameters.Add(new SqlParameter("@Nationality", '0'));

            conn.Open();
            Reg.ExecuteNonQuery();
            conn.Close();

                Message.Enabled = true;
                Message.Text = "Registered Successfully";
                Message.ForeColor = System.Drawing.Color.LawnGreen;
                Continue.Enabled = true;
            }
            }
            catch(ArgumentNullException)
            {
                Message.Enabled = true;
                Message.Text = "Insert Data";
                Message.ForeColor = System.Drawing.Color.DarkRed;
            }
}

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/General.aspx");
        }
    }
}