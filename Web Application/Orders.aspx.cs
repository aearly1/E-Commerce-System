using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class MyOrders : System.Web.UI.Page
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

            SqlCommand cmd = new SqlCommand("myOrders", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string username = (String)Session["username"];
            cmd.Parameters.Add(new SqlParameter("@customername", username));

            conn.Open();

            //IF the output is a table, then we can read the records one at a time
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Label myOrders = new Label();
            myOrders.Text = "My orders: " + "  <br /> <br />";
            form.Controls.Add(myOrders);

            while (rdr.Read())
            {
                //Get the value of the attribute name in the Company table
                int order_no = rdr.GetInt32(rdr.GetOrdinal("order_no"));
                //Get the value of the attribute field in the Company table
                decimal total_amount = rdr.GetDecimal(rdr.GetOrdinal("total_amount"));

                //Create a new label and add it to the HTML form
                Label lbl_order_no = new Label();
                lbl_order_no.Text = "order number: " + order_no.ToString();
                form.Controls.Add(lbl_order_no);


                Label lbl_total_amount = new Label();
                lbl_total_amount.Text = "total: " + total_amount;
                lbl_total_amount.Attributes.Add("style", "left: 140px; position: absolute;");
                form.Controls.Add(lbl_total_amount);


                Button cancle_Button = new Button();
                cancle_Button.ID = "" + order_no;
                cancle_Button.Text = "Cancel order " + order_no;
                cancle_Button.Click += new System.EventHandler(this.display);
                cancle_Button.Attributes.Add("style", "left: 240px; position: absolute;");
                form.Controls.Add(cancle_Button);

                Button payment_Button = new Button();
                payment_Button.ID = "" + '-' + order_no;
                payment_Button.Text = "Pay for order " + order_no;
                payment_Button.Click += new System.EventHandler(this.CashOrCredit);
                payment_Button.Attributes.Add("style", "left: 370px; position: absolute;");

                form.Controls.Add(payment_Button);

                Label newLine = new Label();
                newLine.Text = ("</br> </br>");
                form.Controls.Add(newLine);
            }
        }
    }
    protected void MakeOrder(object sender, EventArgs e)
    {
        //Get the information of the connection to the database
        string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
        //create a new connection
        SqlConnection conn = new SqlConnection(connStr);
        /*create a new SQL command which takes as parameters the name of the stored procedure and
        the SQLconnection name*/

        SqlCommand cmd = new SqlCommand("makeOrder", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        //To read the input from the user
        string username = (String)Session["username"];
        cmd.Parameters.Add(new SqlParameter("@customername", username));
        SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Bit);
        success.Direction = ParameterDirection.Output;

        //Executing the SQLCommand


        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
            //To navigate to another webpage
            

        if (success.Value.ToString().Equals("True"))
        {
            Response.Write("<script>alert('Thank you, your order has been placed.');</script>");
            Response.Write("<script>location.href='Orders.aspx'</script>");

        }
        else
        {
            Response.Write("<script>alert('Sorry, unable to make order since your cart cart is empty. Please add items to your cart before attempting to make an order ');</script>");
        }
        
    }
    protected void Button_Click(object sender, EventArgs e)
    {
        Response.Redirect("Add_Credit_Card.aspx", true);

    }

    protected void BackToHome(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx", true);

    }

    protected void display(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        int order_no = Int32.Parse(b.ID);

        string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

        SqlConnection conn = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand("cancelOrder", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        //To read the input from the user
        string username = (String)Session["username"];
        cmd.Parameters.Add(new SqlParameter("@orderid", order_no));
        cmd.Parameters.Add(new SqlParameter("@customername", username));
        SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Bit);
        success.Direction = ParameterDirection.Output;

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        if(success.Value.ToString().Equals("True"))
        {
            Response.Write("<script>alert('Successfully cancled your order')</script>");
            Response.Write("<script>location.href='Orders.aspx'</script>");
        }
        else if (success.Value.ToString().Equals("False"))
        {
            Response.Write("<script>alert('Failed to cancel  product because it is either out for delivery or has been delivered')</script>");
        }
    }

    protected void CashOrCredit(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        int order_no = -1*Int32.Parse(b.ID);

        string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

        SqlConnection conn = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand("SpecifyAmount", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        //To read the input from the user
        string username = (String)Session["username"];
        try
        {
            decimal amount = decimal.Parse(Amount.Text);
            decimal zero = 0;

            cmd.Parameters.Add(new SqlParameter("@customername", username));
            cmd.Parameters.Add(new SqlParameter("@orderid", order_no));
            if (DropDownList1.SelectedIndex == 0)
            {
                cmd.Parameters.Add(new SqlParameter("@cash", amount));
                cmd.Parameters.Add(new SqlParameter("@credit", zero));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@cash", zero));
                cmd.Parameters.Add(new SqlParameter("@credit", amount));
            }
            SqlParameter success = cmd.Parameters.Add("@case", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            if (success.Value.ToString().Equals("0"))
            {
                Response.Write("<script>alert('Unable to pay for order since there are not enough points to complete purchase')</script>");
            }
            else if (success.Value.ToString().Equals("1"))
            {
                Response.Write("<script>alert('Unable to pay for order since the amount specified is larger than the total. Please specify a smaller amount')</script>");
            }
            else if (success.Value.ToString().Equals("2"))
            {
                Response.Write("<script>alert('Purchase successful. Your points has been updated')</script>");
            }
        }
        catch(FormatException)
        {
            Response.Write("<script>alert('Unable to pay for order, since you did not specify the amount. Please do so')</script>");
        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}