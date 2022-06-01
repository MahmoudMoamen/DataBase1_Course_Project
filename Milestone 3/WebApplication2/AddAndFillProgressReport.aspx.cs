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
    public partial class AddAndFillProgressReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
                SqlConnection conn = new SqlConnection(connectionString);

                HttpCookie aCookie = Request.Cookies["loginCookie1"];
                String id = Server.HtmlEncode(aCookie.Value);
                int flagparse = int.Parse(id);

                String tsn = TSN.Text;
                String prd = PRD.Text;
                String prn = PRN.Text;

                HttpCookie ThesisSerialNo = new HttpCookie("loginCookie");
                Response.Cookies["ThesisSerialNo"].Value = tsn;
                Response.Cookies.Add(ThesisSerialNo);

                HttpCookie ProgressReportDate = new HttpCookie("loginCookie");
                Response.Cookies["ProgressReportDate"].Value = prd;
                Response.Cookies.Add(ProgressReportDate);

                HttpCookie ProgressReportNo = new HttpCookie("loginCookie");
                Response.Cookies["ProgressReportNo"].Value = prn;
                Response.Cookies.Add(ProgressReportNo);

                if (tsn.Equals("") || prd.Equals("") || prn.Equals(""))
                    throw new ArgumentNullException();
                else
                {
                    SqlCommand Reg = new SqlCommand("AddProgressReport", conn);
                    Reg.CommandType = CommandType.StoredProcedure;
                    Reg.Parameters.Add(new SqlParameter("@thesisSerialNo", tsn));
                    Reg.Parameters.Add(new SqlParameter("@progressReportDate", prd));
                    Reg.Parameters.Add(new SqlParameter("@studentID", flagparse));
                    Reg.Parameters.Add(new SqlParameter("@progressReportNo", prn));

                    conn.Open();
                    Reg.ExecuteNonQuery();
                    conn.Close();

                    TSN.Enabled = false;
                    PRD.Enabled = false;
                    PRN.Enabled = false;
                    Message.Enabled = true;
                    Message.Text = "Progress Report Added Successfully";
                    Message.ForeColor = System.Drawing.Color.LawnGreen;
                    TSN.Text = "";
                    PRD.Text = "";
                    PRN.Text = "";

                    State.Enabled = true;
                    description.Enabled = true;
                    Fill.Enabled = true;
                }
            }
            catch (ArgumentNullException)
            {
                Message.Enabled = true;
                Message.Text = "You have to insert Data";
                Message.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        protected void Fill_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
                SqlConnection conn = new SqlConnection(connectionString);

                HttpCookie aCookie = Request.Cookies["loginCookie1"];
                String id = Server.HtmlEncode(aCookie.Value);
                int flagparse = int.Parse(id);

                HttpCookie aCookie1 = Request.Cookies["ThesisSerialNo"];
                String tsn = Server.HtmlEncode(aCookie1.Value);
                int tsnparse = int.Parse(tsn);

                HttpCookie aCookie2 = Request.Cookies["ProgressReportNo"];
                String prn = Server.HtmlEncode(aCookie2.Value);
                int prnparse = int.Parse(prn);

                int state = int.Parse(State.Text);
                String descriptionn = description.Text;

                if (State.Text.Equals("") || descriptionn.Equals(""))
                    throw new ArgumentNullException();
                else
                {
                    SqlCommand Reg = new SqlCommand("FillProgressReport", conn);
                    Reg.CommandType = CommandType.StoredProcedure;
                    Reg.Parameters.Add(new SqlParameter("@thesisSerialNo", tsnparse));
                    Reg.Parameters.Add(new SqlParameter("@progressReportNo", prnparse));
                    Reg.Parameters.Add(new SqlParameter("@studentID", flagparse));
                    Reg.Parameters.Add(new SqlParameter("@state", state));
                    Reg.Parameters.Add(new SqlParameter("@description", descriptionn));

                    conn.Open();
                    Reg.ExecuteNonQuery();
                    conn.Close();

                    State.Enabled = false;
                    description.Enabled = false;
                    Message2.Enabled = true;
                    Message2.Text = "Progress Report filled Successfully";
                    Message2.ForeColor = System.Drawing.Color.LawnGreen;
                    State.Text = "";
                    description.Text = "";
                }
            }
            catch
            {
                Message2.Enabled = true;
                Message2.Text = "You have to insert Data";
                Message2.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student.aspx");
        }
    }
}