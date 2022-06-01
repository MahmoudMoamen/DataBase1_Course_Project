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
    public partial class AdminIssueThesesPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           

            string strcon = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection con = new SqlConnection(strcon);

            short i;
            decimal k;
            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text) ||
                string.IsNullOrEmpty(TextBox3.Text) || string.IsNullOrEmpty(TextBox3.Text))
            {
                Response.Write("Please Enter The Required Data");
            }
            else
            {
                if (!Int16.TryParse(TextBox1.Text, out i) || !Int16.TryParse(TextBox3.Text, out i))
                {
                    Response.Write("The Required Data Must Be an Integer");
                }
                else
                {
                    if (!Decimal.TryParse(TextBox2.Text, out k) || !Decimal.TryParse(TextBox4.Text, out k))
                    {

                        Response.Write("The Required Data Must Be a Decimal");

                    }
                    else
                    {
                        int serial = Int16.Parse(TextBox1.Text);
                        decimal amount = Decimal.Parse(TextBox2.Text);
                        int no_instal = Int16.Parse(TextBox3.Text);
                        decimal fpercent = Decimal.Parse(TextBox4.Text);

                        SqlCommand AdminIssueThesesPayment = new SqlCommand("AdminIssueThesisPayment", con);
                        AdminIssueThesesPayment.CommandType = CommandType.StoredProcedure;

                        AdminIssueThesesPayment.Parameters.Add(new SqlParameter("@ThesisSerialNo", serial));
                        AdminIssueThesesPayment.Parameters.Add(new SqlParameter("@amount", amount));
                        AdminIssueThesesPayment.Parameters.Add(new SqlParameter("@noOfInstallments", no_instal));
                        AdminIssueThesesPayment.Parameters.Add(new SqlParameter("@fundPercentage", fpercent));

                        SqlParameter success = AdminIssueThesesPayment.Parameters.Add("@success", SqlDbType.Int);
                        success.Direction = ParameterDirection.Output;

                        con.Open();
                        AdminIssueThesesPayment.ExecuteNonQuery();
                        con.Close();


                        if (success.Value.ToString() == "1")
                        {
                            Response.Write("Thesis Payment has been issued successfully");
                        }
                        else
                        {
                            Response.Write("Please Enter a Valid Thesis Serial Number");
                        }



                    }


                }


            }

     

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("availableThesis.aspx");
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}