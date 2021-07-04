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
    public partial class AddToWishList : System.Web.UI.Page
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

                SqlCommand cmd = new SqlCommand("viewWishLists", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                string username =(string) Session["username"];
                cmd.Parameters.Add(new SqlParameter("@customer", username));
                
                conn.Open();

                //IF the output is a table, then we can read the records one at a time
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                Label serial_no_header = new Label();
                serial_no_header.Text = "WishList";
                form1.Controls.Add(serial_no_header);

                while (rdr.Read())
                {
                    string wishList = rdr.GetString(rdr.GetOrdinal("name"));
                    Label wishList_label = new Label();
                    wishList_label.Text = wishList + "  ";
                    form1.Controls.Add(wishList_label);

                    Button wishList_Button = new Button();
                    wishList_Button.CommandName = "" + wishList;
                    wishList_Button.Text = "Add item to " + wishList ;
                    wishList_Button.Click += new System.EventHandler(this.addToWishList);
                    form1.Controls.Add(wishList_Button);

                    Label newLine = new Label();
                    newLine.Text = ("</br> </br>");
                    form1.Controls.Add(newLine);
                }

            }
            
        }
        protected void addToWishList(Object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            
            SqlCommand cmd = new SqlCommand("AddtoWishlist", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string username = (string)Session["username"];
            string wishList = b.CommandName;
            int serial = (Int32)(Session["serial_no"]);
    
            cmd.Parameters.Add(new SqlParameter("@customername", username));
            cmd.Parameters.Add(new SqlParameter("@wishlistname", wishList));
            cmd.Parameters.Add(new SqlParameter("@serial", serial));
          
            Session.Remove("serial_no");

                try
                {
                    //Executing the SQLCommand
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script>alert('Successfully Added the item to the wishlist')</script>");
                    Response.Write("<script>location.href='ViewProducts.aspx'</script>");

                }
                catch (SqlException)
                {
                    Response.Write("<script>alert('Failed to add the item')</script>");
                    Response.Write("<script>location.href='ViewProducts.aspx'</script>");

                }
   
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}