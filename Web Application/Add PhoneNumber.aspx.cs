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
    public partial class Add_PhoneNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("log_in.aspx");
            }
            else if ((int)Session["type"] != 0)
            {
                Session.Abandon();
                Response.Redirect("log_in.aspx");
            }

        }
        protected void AddPhoneNumber(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            /*create a new SQL command which takes as parameters the name of the stored procedure and

            the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("addMobile", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string username = (String)Session["username"];
            string phone = PhoneNumber.Text;
            cmd.Parameters.Add(new SqlParameter("@username", username));
            if(phone!="")
            cmd.Parameters.Add(new SqlParameter("@mobile_number", phone));

            try
            {
                //Executing the SQLCommand
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Successfully Added the phone number')</script>");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Response.Write("<script>alert('The phone number already exists')</script>");
                }
                else
                    Response.Write("<script>alert('Failed to add the phone number')</script>");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}