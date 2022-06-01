using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class User_Login : System.Web.UI.Page
    {
        SqlParameter id;
        SqlParameter type;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void UserLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
                SqlConnection conn = new SqlConnection(connectionString);

                String email = Email.Text;
                String password = Password.Text;
                MessageBox.Enabled = false;

                SqlCommand Reg = new SqlCommand("userLogin", conn);
                Reg.CommandType = CommandType.StoredProcedure;
                Reg.Parameters.Add(new SqlParameter("@email", email));
                Reg.Parameters.Add(new SqlParameter("@password", password));

                SqlParameter outPut = Reg.Parameters.Add("@gucian",SqlDbType.Int);
                outPut.Direction = ParameterDirection.Output;

                SqlParameter outPutParameter = Reg.Parameters.Add("@success", SqlDbType.Bit);
                outPutParameter.Direction = ParameterDirection.Output;

                id= Reg.Parameters.Add("@id", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;


                type= Reg.Parameters.Add("@type", SqlDbType.Int);
                type.Direction = ParameterDirection.Output;

                conn.Open();
                Reg.ExecuteNonQuery();
                conn.Close();
                

                if (email.Equals("") || password.Equals(""))
                    throw new ArgumentNullException();
                else if (type.Value.Equals(0))
                {
                    MessageBox.Enabled = true;
                    MessageBox.Text = "Student Logged in Successfully";
                    MessageBox.ForeColor = System.Drawing.Color.LawnGreen;
                    ContinueButton.Enabled = true;
                }
                else if (type.Value.Equals(1))
                {
                    MessageBox.Enabled = true;
                    MessageBox.Text = "Admin Logged in Successfully";
                    MessageBox.ForeColor = System.Drawing.Color.LawnGreen;
                    ContinueButton.Enabled = true;
                }
                else if (type.Value.Equals(2))
                {
                    MessageBox.Enabled = true;
                    MessageBox.Text = "Supervisor Logged in Successfully";
                    MessageBox.ForeColor = System.Drawing.Color.LawnGreen;
                    ContinueButton.Enabled = true;
                }
                else if (type.Value.Equals(3))
                {
                    MessageBox.Enabled = true;
                    MessageBox.Text = "Examiner Logged in Successfully";
                    MessageBox.ForeColor = System.Drawing.Color.LawnGreen;
                    ContinueButton.Enabled = true;
                }
                else throw new ArgumentException();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Enabled = true;
                MessageBox.Text = "You have to insert Data";
                MessageBox.ForeColor = System.Drawing.Color.DarkRed;

            }
            catch (ArgumentException)
            {
                MessageBox.Enabled = true;
                MessageBox.Text = "This data could not be found on the system";
                MessageBox.ForeColor = System.Drawing.Color.DarkRed;
                Email.Text = "";
                Password.Text = "";
            }
        }
        protected void UserLoginRedirection(object sender,EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            String email=Email.Text;
            String password=Password.Text;
          
            SqlCommand Reg = new SqlCommand("userLogin", conn);
            Reg.CommandType = System.Data.CommandType.StoredProcedure;
            Reg.Parameters.Add(new SqlParameter("@email", email));
            Reg.Parameters.Add(new SqlParameter("@password", password));

            id = Reg.Parameters.Add("@id", System.Data.SqlDbType.Int);
            id.Direction = ParameterDirection.Output;

            SqlParameter outPut1 = Reg.Parameters.Add("@gucian",SqlDbType.Int);
            outPut1.Direction = ParameterDirection.Output;

            SqlParameter outPutParameter = Reg.Parameters.Add("@success", SqlDbType.Bit);
            outPutParameter.Direction = ParameterDirection.Output;

            type = Reg.Parameters.Add("@type", SqlDbType.Int);
            type.Direction = ParameterDirection.Output;
            
            conn.Open();
            Reg.ExecuteNonQuery();
            conn.Close();
            
            HttpCookie loginCookie2 = new HttpCookie("loginCookie");
                Response.Cookies["loginCookie2"].Value = outPut1.Value.ToString();

            if (type.Value.Equals(0))
            {
                HttpCookie loginCookie1 = new HttpCookie("loginCookie");
                Response.Cookies["loginCookie1"].Value = id.Value.ToString();
                Response.Cookies.Add(loginCookie1);
                Response.Redirect("~/Student.aspx");
            }
            else if (type.Value.Equals(1))
                Response.Redirect("???");
            else if (type.Value.Equals(2))
                Response.Redirect("???");
            else if (type.Value.Equals(3))
                Response.Redirect("???");
        }
    }
}