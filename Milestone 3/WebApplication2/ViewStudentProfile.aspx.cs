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
    public partial class ViewStudentProfile : System.Web.UI.Page
    {
        SqlParameter gucian;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
            SqlConnection con = new SqlConnection(strcon);
            HttpCookie aCookie = Request.Cookies["loginCookie1"];
            String sidstr = Server.HtmlEncode(aCookie.Value);
            HttpCookie aCookie2 = Request.Cookies["loginCookie2"];
            String gucianflag = Server.HtmlEncode(aCookie2.Value);
            int flagparse = int.Parse(gucianflag);
            int sidint = int.Parse(sidstr);

            SqlCommand view2 = new SqlCommand("viewMyProfile", con);
            view2.CommandType = CommandType.StoredProcedure;
            view2.Parameters.Add(new SqlParameter("@studentId",sidint));
            gucian = view2.Parameters.Add("@Gucian", SqlDbType.Int);
            gucian.Direction = ParameterDirection.Output;

            con.Open();

            SqlDataReader rdr1 = view2.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr1.Read())
            {

                int id = rdr1.GetInt32(rdr1.GetOrdinal("id"));
                String email = rdr1.GetValue(rdr1.GetOrdinal("email")).ToString();
                String firstName = rdr1.GetValue(rdr1.GetOrdinal("firstName")).ToString();
                String lastName = rdr1.GetValue(rdr1.GetOrdinal("lastName")).ToString();
                String type = rdr1.GetValue(rdr1.GetOrdinal("type")).ToString();
                String faculty = rdr1.GetValue(rdr1.GetOrdinal("faculty")).ToString();
                String address = rdr1.GetValue(rdr1.GetOrdinal("address")).ToString();
                String gpa = rdr1.GetValue(rdr1.GetOrdinal("GPA")).ToString();


                TableRow r = new TableRow();

                TableCell c1 = new TableCell();
                c1.Text = id.ToString();
                c1.Font.Size = FontUnit.Large;

                TableCell c2 = new TableCell();
                c2.Text = email;
                c2.Font.Size = FontUnit.XLarge;

                TableCell c3 = new TableCell();
                c3.Text = firstName;
                c3.Font.Size = FontUnit.XLarge;

                TableCell c4 = new TableCell();
                c4.Text = lastName;
                c4.Font.Size = FontUnit.XLarge;

                TableCell c5 = new TableCell();
                c5.Text = type;
                c5.Font.Size = FontUnit.XLarge;

                TableCell c6 = new TableCell();
                c6.Text = faculty;
                c6.Font.Size = FontUnit.XLarge;

                TableCell c7 = new TableCell();
                c7.Text = address;
                c7.Font.Size = FontUnit.XLarge;

                TableCell c8 = new TableCell();
                c8.Text = gpa;
                c8.Font.Size = FontUnit.XLarge;

                r.Controls.Add(c1);
                r.Controls.Add(c2);
                r.Controls.Add(c3);
                r.Controls.Add(c4);
                r.Controls.Add(c5);
                r.Controls.Add(c6);
                r.Controls.Add(c7);
                r.Controls.Add(c8);

                if (flagparse.Equals(1))
                {
                    String underGradId = rdr1.GetValue(rdr1.GetOrdinal("undergradID")).ToString();
                    TextBox1.Enabled = true;
                    TextBox1.Text = String.Concat("UnderGradID: ",underGradId);
                    TextBox1.ForeColor = System.Drawing.Color.Black;
                }

                StudentProfile.Controls.Add(r);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student.aspx");
        }
    }
}