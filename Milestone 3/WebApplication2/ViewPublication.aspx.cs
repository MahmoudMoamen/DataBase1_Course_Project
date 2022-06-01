﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2

{
    public partial class ViewPublication : System.Web.UI.Page
    {
        protected string Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = null;


            try
            {
                var dataSet = new DataSet();

                connection = new SqlConnection("PostGradOffice");
                connection.Open();

                var command = new SqlCommand("ViewAStudentPublications", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@StudentID", Session["ID"]);
                var dataAdapter = new SqlDataAdapter { SelectCommand = command };

                dataAdapter.Fill(dataSet);

                return dataSet.Tables[0].Rows[0]["Item"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
