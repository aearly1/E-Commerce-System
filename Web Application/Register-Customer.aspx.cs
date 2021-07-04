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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Registration(object sender , EventArgs e)
        {

            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            /*create a new SQL command which takes as parameters the name of the stored procedure and

            the SQLconnection name*/
         

            //To read the input from the user
            string firstname = FirstName.Text;
            string lastname = LastName.Text;
            string username = Username.Text;
            string password = Password.Text;
            string email = Email.Text;
            SqlCommand cmd = new SqlCommand("customerRegister", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (firstname != "" && lastname != "" && username != "" && password != "" && email != "")
            {
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@first_name", firstname));
                cmd.Parameters.Add(new SqlParameter("@last_name", lastname));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                cmd.Parameters.Add(new SqlParameter("@email", email));
            }



            //Executing the SQLCommand
            try
            {  
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Registration Successful as a Customer');</script>");
                Response.Write("<script>location.href='log_in.aspx'</script>");

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Response.Write("<script>alert('The username already exists')</script>");
                }
                else
                    Response.Write("<script>alert('Registration failed. You did not fill in all the required fields');</script>");
            }
     

        }
        


    }
}