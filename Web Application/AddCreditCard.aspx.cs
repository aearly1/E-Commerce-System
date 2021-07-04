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
    public partial class AddCreditCard : System.Web.UI.Page
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
        protected void AddCard(object sender, EventArgs e)
        {
                //Get the information of the connection to the database
                string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                /*create a new SQL command which takes as parameters the name of the stored procedure and

                the SQLconnection name*/
                SqlCommand cmd = new SqlCommand("AddCreditCard", conn);
                cmd.CommandType = CommandType.StoredProcedure;
            
                //To read the input from the user
                string username = (String)Session["username"];
                string cvv = CVV.Text;
            try
            {
                DateTime expirydate = DateTime.Parse(date.Value);
                string creditCard = CreditCard.Text;
                if (username != "" && cvv != "" && creditCard != "")
                {
                    cmd.Parameters.Add(new SqlParameter("@customername", username));
                    cmd.Parameters.Add(new SqlParameter("@cvv", cvv));
                    cmd.Parameters.Add(new SqlParameter("@expirydate", expirydate));
                    cmd.Parameters.Add(new SqlParameter("@creditcardnumber", creditCard));
                }
                try
                {
                    //Executing the SQLCommand
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script>alert('Successfully Added the credit card')</script>");
                }
                catch (SqlException ex)
                { if(ex.Number == 2627)
                    {
                        Response.Write("<script>alert('The credit card number already exists')</script>");
                    }
                    else { 
                    Response.Write("<script>alert('Failed to add the credit card')</script>");
                }
                }

            }
            catch (System.FormatException)
            {
                Response.Write("<script>alert('Please, Enter the date as MM/DD/YYYY')</script>");
            }
            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
    }
    