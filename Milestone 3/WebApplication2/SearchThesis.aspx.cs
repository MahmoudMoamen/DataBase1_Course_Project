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
    public partial class SearchThesis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void searching_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["PostGradOfficee"].ToString();
            SqlConnection con = new SqlConnection(strcon);

            if (String.IsNullOrEmpty(thesistitle.Text))
                Response.Write("<script>alert('Please Enter Thesis Title');</script>");
            else
            {   string word= thesistitle.Text;

                SqlCommand searchth = new SqlCommand("Searchproc", con);
                searchth.CommandType = CommandType.StoredProcedure;
                searchth.Parameters.Add(new SqlParameter("@keyword", word));
                con.Open();
                SqlDataReader rdr1 = searchth.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                
                while (rdr1.Read())
                {

                    int sN = rdr1.GetInt32(rdr1.GetOrdinal("serialNumber"));
                    String field = rdr1.GetString(rdr1.GetOrdinal("field"));
                    String type = rdr1.GetString(rdr1.GetOrdinal("type"));
                    String title = rdr1.GetString(rdr1.GetOrdinal("title"));
                    DateTime sD = rdr1.GetDateTime(rdr1.GetOrdinal("startDate"));
                    DateTime eD = rdr1.GetDateTime(rdr1.GetOrdinal("endDate"));
                    DateTime dD = rdr1.GetDateTime(rdr1.GetOrdinal("defenseDate"));
                    int years = rdr1.GetInt32(rdr1.GetOrdinal("years"));
                    decimal grade = rdr1.GetDecimal(rdr1.GetOrdinal("grade"));
                    int pID = rdr1.GetInt32(rdr1.GetOrdinal("payment_id"));
                    int ne = rdr1.GetInt32(rdr1.GetOrdinal("noOfExtensions"));


                    TableRow r = new TableRow();

                    TableCell c1 = new TableCell();
                    c1.Text = sN.ToString();
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
                    c5.Text = sD.ToString();
                    c5.Font.Size = FontUnit.XLarge;

                    TableCell c6 = new TableCell();
                    c6.Text = eD.ToString();
                    c6.Font.Size = FontUnit.XLarge;

                    TableCell c7 = new TableCell();
                    c7.Text = dD.ToString();
                    c7.Font.Size = FontUnit.XLarge;

                    TableCell c8 = new TableCell();
                    c8.Text = years.ToString();
                    c8.Font.Size = FontUnit.XLarge;

                    TableCell c9 = new TableCell();
                    c9.Text = grade.ToString();
                    c9.Font.Size = FontUnit.XLarge;

                    TableCell c10 = new TableCell();
                    c10.Text = pID.ToString();
                    c10.Font.Size = FontUnit.XLarge;

                    TableCell c11 = new TableCell();
                    c11.Text = ne.ToString();
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


                    Thesis.Controls.Add(r);
                    
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorView.aspx");
        }
    }
}