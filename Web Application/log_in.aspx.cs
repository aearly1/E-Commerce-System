using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Mashroo3Qa3edetTa5zeenMa3loomat
{
    public partial class log_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Login(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            /*create a new SQL command which takes as parameters the name of the stored procedure and

            the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("userLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string username = Username.Text;
            string password = Password.Text;
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));

            //Save the output from the procedure
            SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Bit);
            success.Direction = ParameterDirection.Output;
            SqlParameter type = cmd.Parameters.Add("@type", SqlDbType.Int);
            type.Direction = ParameterDirection.Output;
            try {
                //Executing the SQLCommand
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();


                if (success.Value.ToString().Equals("True"))
                {

                    /*ASP.NET session state enables you to store and retrieve values for a user
                    as the user navigates ASP.NET pages in a Web application.
                    This is how we store a value in the session*/
                    Response.Write("<script>alert('Logged in successfully')</script>");
                    Session["username"] = username;
               
                    if(type.Value.ToString().Equals("0"))
                    {
                        Session["type"] = 0;
                        Response.Write("<script>location.href='Home.aspx'</script>");

                    }else if(type.Value.ToString().Equals("1"))
                    {
                        Session["type"] = 1;
                        Response.Write("<script>location.href='VendorHome.aspx'</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('Please enter a correct Username or Password')</script>");
                }

            }
            catch (SqlException)
            {
                Response.Write("<script>alert('Failed to Login')</script>");
            }
            }

    }
}