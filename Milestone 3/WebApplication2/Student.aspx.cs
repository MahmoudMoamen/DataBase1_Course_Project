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
    public partial class Student : System.Web.UI.Page
    {
        int ID;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ViewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewStudentProfile.aspx");
            
        }

        protected void ListingThesis_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ListingThesis.aspx");
        }

        protected void ViewingCourses_Click(object sender, EventArgs e)
        {
            HttpCookie aCookie4 = Request.Cookies["loginCookie2"];
            String gucian = Server.HtmlEncode(aCookie4.Value);
            int flagparse = int.Parse(gucian);
            if (flagparse.Equals(0))
            {
                Response.Redirect("~/ViewingCourses.aspx");
            }
            else
                Response.Write("This option is not for Gucian Students");
        }

        protected void AddProgressReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddAndFillProgressReport.aspx");
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddAndLinkPublicationToOngoingThesis.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserLogin.aspx");
        }
    }
}