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
    public partial class Supervisor_Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SupervisorRegister(object sender, EventArgs e)
        {
            try {
            string connectionString = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            String Firstname = SupFirstName.Text;
            String Lastname = SupLastName.Text;
            String Pass = SupPassword.Text;
            String Facu = SupFaculty.Text;
            String mail = SupEmail.Text;

            if (Firstname.Equals("") || Lastname.Equals("") || Pass.Equals("") || Facu.Equals("") || mail.Equals(""))
                    throw new ArgumentNullException();
            else{
                    SqlCommand SupReg = new SqlCommand("supervisorRegister", conn);
            SupReg.CommandType = System.Data.CommandType.StoredProcedure;
            SupReg.Parameters.Add(new SqlParameter("@first_name", Firstname));
            SupReg.Parameters.Add(new SqlParameter("@last_name", Lastname));
            SupReg.Parameters.Add(new SqlParameter("@password", Pass));
            SupReg.Parameters.Add(new SqlParameter("@faculty", Facu));
            SupReg.Parameters.Add(new SqlParameter("@email", mail));

            conn.Open();
            SupReg.ExecuteNonQuery();
            conn.Close();

                Message.Enabled = true;
                Message.Text = "Registered Successfully";
                Message.ForeColor = System.Drawing.Color.LawnGreen;
                Button2.Enabled = true;
                Button3.Enabled = true;
            }
            }
            catch(ArgumentNullException)
            {
                Message.Enabled = true;
                Message.Text = "Insert Data";
                Message.ForeColor = System.Drawing.Color.DarkRed;
            }
}

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("General.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserLogin.aspx");
        }
    }
}