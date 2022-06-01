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
    public partial class Student_Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void StudentRegister(object sender, EventArgs e)
        {
            try
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
                SqlConnection conn = new SqlConnection(connectionString);

                String Firstname = FirstName.Text;
                String Lastname = LastName.Text;
                String Pass = Password.Text;
                String Facu = Faculty.Text;
                String mail = Email.Text;
                String add = Address.Text;
                String Guc = RadioButtonList.SelectedValue;

                if (Firstname.Equals("") || Lastname.Equals("") || Pass.Equals("") || Facu.Equals("") || mail.Equals("") || add.Equals(""))
                    throw new ArgumentNullException();
                else
                {
                    SqlCommand Reg = new SqlCommand("studentRegister", conn);
                    Reg.CommandType = System.Data.CommandType.StoredProcedure;
                    Reg.Parameters.Add(new SqlParameter("@first_name", Firstname));
                    Reg.Parameters.Add(new SqlParameter("@last_name", Lastname));
                    Reg.Parameters.Add(new SqlParameter("@password", Pass));
                    Reg.Parameters.Add(new SqlParameter("@email", mail));
                    Reg.Parameters.Add(new SqlParameter("@faculty", Facu));
                    Reg.Parameters.Add(new SqlParameter("@address", add));
                    if (Guc.Equals("true"))
                    {
                        Reg.Parameters.Add(new SqlParameter("@Gucian", '1'));

                    }
                    else
                    {
                        Reg.Parameters.Add(new SqlParameter("@Gucian", '0'));
                    }

                    conn.Open();
                    Reg.ExecuteNonQuery();
                    conn.Close();

                    Message.Enabled = true;
                    Message.Text = "Registered Successfully";
                    Message.ForeColor = System.Drawing.Color.LawnGreen;
                    Button2.Enabled = true;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserLogin.aspx");
        }
    }
}