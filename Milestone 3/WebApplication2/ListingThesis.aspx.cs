using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ListingThesis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
            SqlConnection con = new SqlConnection(strcon);
            HttpCookie aCookie = Request.Cookies["loginCookie1"];
            String sidstr = Server.HtmlEncode(aCookie.Value);
            int sidint = int.Parse(sidstr);

            SqlCommand view2 = new SqlCommand("ListAllmyTheses", con);
            view2.CommandType = System.Data.CommandType.StoredProcedure;
            view2.Parameters.Add(new SqlParameter("@id", sidint));

            con.Open();
            SqlDataReader rdr1 = view2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr1.Read())
            {

                int sn = rdr1.GetInt32(rdr1.GetOrdinal("serialNumber"));
                String field = rdr1.GetValue(rdr1.GetOrdinal("field")).ToString();
                String type = rdr1.GetValue(rdr1.GetOrdinal("type")).ToString();
                String title = rdr1.GetValue(rdr1.GetOrdinal("title")).ToString();
                String startDate = rdr1.GetValue(rdr1.GetOrdinal("startDate")).ToString();
                String endDate = rdr1.GetValue(rdr1.GetOrdinal("endDate")).ToString();
                String defenseDate = rdr1.GetValue(rdr1.GetOrdinal("defenseDate")).ToString();
                String years = rdr1.GetValue(rdr1.GetOrdinal("years")).ToString();
                String grade = rdr1.GetValue(rdr1.GetOrdinal("grade")).ToString();
                String payment_id = rdr1.GetValue(rdr1.GetOrdinal("defenseDate")).ToString();
                String noOfExtensions = rdr1.GetValue(rdr1.GetOrdinal("defenseDate")).ToString();


                TableRow r = new TableRow();

                TableCell c1 = new TableCell();
                c1.Text = sn.ToString();
                c1.Font.Size = FontUnit.Large;

                TableCell c2 = new TableCell();
                c2.Text = field;
                c2.Font.Size = FontUnit.XLarge;

                TableCell c3 = new TableCell();
                c3.Text = type;
                c3.Font.Size = FontUnit.XLarge;

                TableCell c4 = new TableCell();
                c4.Text = title;
                c4.Font.Size = FontUnit.XLarge;

                TableCell c5 = new TableCell();
                c5.Text = startDate;
                c5.Font.Size = FontUnit.XLarge;

                TableCell c6 = new TableCell();
                c6.Text = endDate;
                c6.Font.Size = FontUnit.XLarge;

                TableCell c7 = new TableCell();
                c7.Text = defenseDate;
                c7.Font.Size = FontUnit.XLarge;

                TableCell c8 = new TableCell();
                c8.Text = years;
                c8.Font.Size = FontUnit.XLarge;

                TableCell c9 = new TableCell();
                c9.Text = grade;
                c9.Font.Size = FontUnit.XLarge;

                TableCell c10 = new TableCell();
                c10.Text = payment_id;
                c10.Font.Size = FontUnit.XLarge;

                TableCell c11 = new TableCell();
                c11.Text = noOfExtensions;
                c11.Font.Size = FontUnit.XLarge;

                r.Controls.Add(c1);
                r.Controls.Add(c2);
                r.Controls.Add(c3);
                r.Controls.Add(c4);
                r.Controls.Add(c5);
                r.Controls.Add(c6);
                r.Controls.Add(c7);
                r.Controls.Add(c8);
                r.Controls.Add(c9);
                r.Controls.Add(c10);
                r.Controls.Add(c11);

                Theses.Controls.Add(r);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student.aspx");
        }
    }
}