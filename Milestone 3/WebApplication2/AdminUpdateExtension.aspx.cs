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
    public partial class AdminUpdateExtension : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
           
        
            
                string strcon = WebConfigurationManager.ConnectionStrings["PostGradOffice1"].ToString();
                SqlConnection con = new SqlConnection(strcon);

            short i;
            if (string.IsNullOrEmpty(TextBox1.Text))
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

                    int serial = Int16.Parse(TextBox1.Text);


                    SqlCommand AdminUpdateExtension = new SqlCommand("AdminUpdateExtension", con);
                    AdminUpdateExtension.CommandType = CommandType.StoredProcedure;

                    AdminUpdateExtension.Parameters.Add(new SqlParameter("@ThesisSerialNo", serial));

                    SqlParameter success = AdminUpdateExtension.Parameters.Add("@success", SqlDbType.Int);
                    success.Direction = ParameterDirection.Output;

                    con.Open();
                    AdminUpdateExtension.ExecuteNonQuery();
                    con.Close();

                    if (success.Value.ToString() == "1")
                    {
                        Response.Write("Thesis Extention Updated Sucessfulyy");
                    }
                    else
                    {
                        Response.Write("Please Enter a Valid Theses Serial Number");

                    }


                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("availableThesis2.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}