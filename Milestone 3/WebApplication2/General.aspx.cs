using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class General : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Student_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentRegister.aspx");
        }

        protected void Supervisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SupervisorRegister.aspx");
        }

        protected void Examiner_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ExaminerRegister.aspx");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserLogin.aspx");
        }
    }
}