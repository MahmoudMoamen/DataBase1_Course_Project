using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace WebApplication2
{
    public partial class AdminIssueInstallPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
            SqlConnection con = new SqlConnection(strcon);

            short i;

            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text))
                          
            {
                Response.Write("Please Enter The Required Data");
            }
            else
            {

                if (!Int16.TryParse(TextBox1.Text, out i))
                {
                    Response.Write("The Required Data Must Be an Integer");
                }

                else
                {
                    int paymentid = Int16.Parse(TextBox1.Text);
                    string date = TextBox2.Text;

                    SqlCommand AdminIssueInstallPayment = new SqlCommand("AdminIssueInstallPayment2", con);
                    AdminIssueInstallPayment.CommandType = CommandType.StoredProcedure;

                    AdminIssueInstallPayment.Parameters.Add(new SqlParameter("@paymentID", paymentid));
                    AdminIssueInstallPayment.Parameters.Add(new SqlParameter("@InstallStartDate", date));

                    SqlParameter success = AdminIssueInstallPayment.Parameters.Add("@success", SqlDbType.Int);
                    success.Direction = ParameterDirection.Output;

                    con.Open();
                    AdminIssueInstallPayment.ExecuteNonQuery();
                    con.Close();

                    if (success.Value.ToString() == "1")
                    {
                        Response.Write("Payment has been issued Successfully");
                    }
                    else
                    {
                        Response.Write("Please Enter a Valid Payment ID");
                    }

                }
            }

           


           

          
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AvailablePayments.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}