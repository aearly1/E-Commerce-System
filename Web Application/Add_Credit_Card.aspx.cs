using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class Add_Credit_Card : System.Web.UI.Page
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
        else
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("myCreditCard", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string username = (String)Session["username"];
            cmd.Parameters.Add(new SqlParameter("@customername", username));

            conn.Open();

            //IF the output is a table, then we can read the records one at a time
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Label myCC = new Label();
            myCC.Text = "Choose one of the following credit cards" + "  <br /> <br />";
            form1.Controls.Add(myCC);

            while (rdr.Read())
            {
                //Get the value of the attribute name in the Company table
                String cc_no = rdr.GetString(rdr.GetOrdinal("cc_number"));

                //Create a new label and add it to the HTML form
                Label lbl_cc_no = new Label();
                lbl_cc_no.Text = cc_no + "  <br /> <br />";
                form1.Controls.Add(lbl_cc_no);

            }
            conn.Close();
            conn.Open();

            cmd = new SqlCommand("myOrders", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@customername", username));

            //IF the output is a table, then we can read the records one at a time
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Label myOrders = new Label();
            myOrders.Text = "Choose one of the following order numbers" + "  <br /> <br />";
            form1.Controls.Add(myOrders);

            while (rdr.Read())
            {
                //Get the value of the attribute name in the Company table
                int order_no = rdr.GetInt32(rdr.GetOrdinal("order_no"));
                //Get the value of the attribute field in the Company table
                decimal total_amount = rdr.GetDecimal(rdr.GetOrdinal("total_amount"));

                //Create a new label and add it to the HTML form
                Label lbl_order_no = new Label();
                lbl_order_no.Text = order_no.ToString() + "  <br /> <br />";
                form1.Controls.Add(lbl_order_no);

            }
            //this is how you retrive data from session variable.
        }

    }
    protected void Submitt(object sender, EventArgs e)
    {
        //Get the information of the connection to the database
        string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
        //create a new connection
        SqlConnection conn = new SqlConnection(connStr);
        /*create a new SQL command which takes as parameters the name of the stored procedure and

        the SQLconnection name*/

        SqlCommand cmd = new SqlCommand("ChooseCreditCard", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        //To read the input from the user
        string username = (String)Session["username"];
        try
        {
            String Creditcard = Creditcard_Text.Text;
            int Order = Int32.Parse(Order_Text.Text);
            cmd.Parameters.Add(new SqlParameter("@customer", username));
            cmd.Parameters.Add(new SqlParameter("@creditcard", Creditcard));
            cmd.Parameters.Add(new SqlParameter("@orderid", Order));
            SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Bit);
            success.Direction = ParameterDirection.Output;

            //Executing the SQLCommand
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            //To navigate to another webpage


            if (success.Value.ToString().Equals("True"))
            {
                Response.Write("<script>alert('Credit card added to order');</script>");

            }
            else
            {
                Response.Write("<script>alert('Error. Invalid credit card or order number. ');</script>");
            }
        }
        catch(FormatException)
        {
            Response.Write("<script>alert('Error. Please enter values for credit card number and order number')</script>");
        }

    }

    protected void ordersPage(object sender, EventArgs e)
    {
        Response.Redirect("Orders.aspx", true);
    }

}
