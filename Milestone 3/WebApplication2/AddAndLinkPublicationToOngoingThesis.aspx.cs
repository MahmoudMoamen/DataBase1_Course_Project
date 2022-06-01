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
    public partial class AddAndLinkPublicationToOngoingThesis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
                SqlConnection conn = new SqlConnection(connectionString);

                String title = Title.Text;
                String date = Date.Text;
                String host = Host.Text;
                String place = Place.Text;
                Boolean accepted = CheckBox.Checked;

                if (title.Equals("") || date.Equals("") || host.Equals("") || place.Equals(""))
                    throw new ArgumentNullException();
                else
                {
                    SqlCommand Reg = new SqlCommand("addPublication", conn);
                    Reg.CommandType = CommandType.StoredProcedure;
                    Reg.Parameters.Add(new SqlParameter("@title", title));
                    Reg.Parameters.Add(new SqlParameter("@pubDate", date));
                    Reg.Parameters.Add(new SqlParameter("@host", host));
                    Reg.Parameters.Add(new SqlParameter("@place", place));
                    Reg.Parameters.Add(new SqlParameter("@accepted", accepted));

                    SqlParameter pubID = Reg.Parameters.Add("@PUBID", SqlDbType.Int);
                    pubID.Direction = ParameterDirection.Output;

                    conn.Open();
                    Reg.ExecuteNonQuery();
                    conn.Close();

                    HttpCookie PublID = new HttpCookie("loginCookie");
                    Response.Cookies["PubId"].Value = pubID.Value.ToString();
                    Response.Cookies.Add(PublID);

                    Title.Enabled = false;
                    Date.Enabled = false;
                    Host.Enabled = false;
                    Place.Enabled = false;
                    MessageBox.Enabled = true;
                    MessageBox.Text = "Publication Added Successfully";
                    MessageBox.ForeColor = System.Drawing.Color.LawnGreen;
                    Title.Text = "";
                    Date.Text = "";
                    Host.Text = "";
                    Place.Text = "";
                    LinkButton.Enabled = true;
                }
            }
            catch (ArgumentNullException)
            {
                Title.Text = "";
                Date.Text = "";
                Host.Text = "";
                Place.Text = "";
                MessageBox.Enabled = true;
                MessageBox.Text = "You have to insert Data";
                MessageBox.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
                string connectionString = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
                SqlConnection conn = new SqlConnection(connectionString);

                HttpCookie aCookie = Request.Cookies["PubId"];
                String pidstr = Server.HtmlEncode(aCookie.Value);
                int pidint = int.Parse(pidstr);

                HttpCookie aCookie1 = Request.Cookies["ThesisSerialNo"];
                String tsn = Server.HtmlEncode(aCookie1.Value);
                int tsnParse = int.Parse(tsn);

                SqlCommand Reg = new SqlCommand("linkPubThesis", conn);
                Reg.CommandType = CommandType.StoredProcedure;
                Reg.Parameters.Add(new SqlParameter("@PubID", pidint));
                Reg.Parameters.Add(new SqlParameter("@thesisSerialNo", tsnParse));

                conn.Open();
                Reg.ExecuteNonQuery();
                conn.Close();

                Message2.Enabled = true;
                Message2.Text = "Publication linked Successfully";
                Message2.ForeColor = System.Drawing.Color.LawnGreen;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student.aspx");
        }
    }
}