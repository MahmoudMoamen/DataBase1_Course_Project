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
    public partial class ViewingCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();

            HttpCookie aCookie5 = Request.Cookies["loginCookie1"];
            String sidstr = Server.HtmlEncode(aCookie5.Value);
            int sidint = int.Parse(sidstr);
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand view2 = new SqlCommand("ViewCoursesGrades", con);
            view2.CommandType = CommandType.StoredProcedure;
            view2.Parameters.Add(new SqlParameter("@studentId", sidint));

            con.Open();

            SqlDataReader rdr1 = view2.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr1.Read())
            {
                String code = rdr1.GetValue(rdr1.GetOrdinal("code")).ToString();
                String creditHours = rdr1.GetValue(rdr1.GetOrdinal("creditHours")).ToString();
                String fees = rdr1.GetValue(rdr1.GetOrdinal("fees")).ToString();
                String grade = rdr1.GetValue(rdr1.GetOrdinal("grade")).ToString();
                TableRow r = new TableRow();

                TableCell c1 = new TableCell();
                c1.Text = code;
                c1.Font.Size = FontUnit.Large;

                TableCell c2 = new TableCell();
                c2.Text = creditHours;
                c2.Font.Size = FontUnit.XLarge;

                TableCell c3 = new TableCell();
                c3.Text = fees;
                c3.Font.Size = FontUnit.XLarge;

                TableCell c4 = new TableCell();
                c4.Text = grade;
                c4.Font.Size = FontUnit.XLarge;

                r.Controls.Add(c1);
                r.Controls.Add(c2);
                r.Controls.Add(c3);
                r.Controls.Add(c4);

                ViewCourses.Controls.Add(r);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student.aspx");
        }
    }
}