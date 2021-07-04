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
    public partial class ViewProducts : System.Web.UI.Page
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

                SqlCommand cmd = new SqlCommand("ShowProductsbyPrice", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                //IF the output is a table, then we can read the records one at a time
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                Label serial_no_header = new Label();
                serial_no_header.Text = "Product Serial Number  ";
                form1.Controls.Add(serial_no_header);

                Label vendor_username_header = new Label();
                vendor_username_header.Attributes.Add("style", "left: 180px; position: absolute;");
                vendor_username_header.Text = "Vendor ";
                form1.Controls.Add(vendor_username_header);

                Label product_name_header = new Label();
                product_name_header.Text = "Product Name  ";
                product_name_header.Attributes.Add("style","left: 360px; position: absolute;");
                form1.Controls.Add(product_name_header);

                Label category_header = new Label();
                category_header.Text = "Category  ";
                category_header.Attributes.Add("style", "left: 540px; position: absolute;");
                form1.Controls.Add(category_header);

                Label product_description_header = new Label();
                product_description_header.Text = "Product Description  ";
                product_description_header.Attributes.Add("style", "left: 650px; position: absolute;");
                form1.Controls.Add(product_description_header);

                Label price_header = new Label();
                price_header.Text = "Price  ";
                price_header.Attributes.Add("style", "left: 840px; position: absolute;");
                form1.Controls.Add(price_header);

                Label final_price_header = new Label();
                final_price_header.Text = "Final Price  ";
                final_price_header.Attributes.Add("style", "left: 910px; position: absolute;");
                form1.Controls.Add(final_price_header);

                Label color_header = new Label();
                color_header.Text = "Color  ";
                color_header.Attributes.Add("style", "left: 1000px; position: absolute;");
                form1.Controls.Add(color_header);

                Label rate_header = new Label();
                rate_header.Text = "Rate  ";
                rate_header.Attributes.Add("style", "left: 1080px; position: absolute;");
                form1.Controls.Add(rate_header);


                Label addToCart_header = new Label();
                addToCart_header.Text = "Add product to cart " ;
                addToCart_header.Attributes.Add("style", "left: 1150px; position: absolute;");
                form1.Controls.Add(addToCart_header);

                Label newLine = new Label();
                newLine.Text = ("</br> </br>");
                form1.Controls.Add(newLine);

                form1.Attributes.Add("runat", "server");

                while (rdr.Read())
                {




                    int serial_no = rdr.GetInt32(rdr.GetOrdinal("serial_no"));
                    string vendor_username = rdr.GetString(rdr.GetOrdinal("vendor_username"));
                    string product_name = rdr.GetString(rdr.GetOrdinal("product_name"));
                    string category = rdr.GetString(rdr.GetOrdinal("category"));
                    string product_description = rdr.GetString(rdr.GetOrdinal("product_description"));
                    decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                    decimal final_price = rdr.GetDecimal(rdr.GetOrdinal("final_price"));
                    string color = rdr.GetString(rdr.GetOrdinal("color"));
                    Boolean available = rdr.GetBoolean(rdr.GetOrdinal("available"));
                    int rate = rdr.GetInt32(rdr.GetOrdinal("rate"));

                    Label serial_no_label = new Label();
                    serial_no_label.Text = serial_no + "  ";
                    form1.Controls.Add(serial_no_label);

                    Label vendor_username_label = new Label();
                    vendor_username_label.Text = vendor_username + "  ";
                    vendor_username_label.Attributes.Add("style", "left: 180px; position: absolute;");
                    form1.Controls.Add(vendor_username_label);

                    Label product_name_label = new Label();
                    product_name_label.Text = product_name + "  ";
                    product_name_label.Attributes.Add("style", "left: 360px; position: absolute;");
                    form1.Controls.Add(product_name_label);

                    Label category_label = new Label();
                    category_label.Text = category + "  ";
                    category_label.Attributes.Add("style", "left: 540px; position: absolute;");
                    form1.Controls.Add(category_label);

                    Label product_description_label = new Label();
                    product_description_label.Text = product_description + "  ";
                    product_description_label.Attributes.Add("style", "left: 650px; position: absolute;");
                    form1.Controls.Add(product_description_label);


                    Label price_label = new Label();
                    price_label.Text = price + "  ";
                    price_label.Attributes.Add("style", "left: 840px; position: absolute;");
                    form1.Controls.Add(price_label);

                    Label final_price_label = new Label();
                    final_price_label.Text = final_price + "  ";
                    final_price_label.Attributes.Add("style", "left: 910px; position: absolute;");
                    form1.Controls.Add(final_price_label);


                    Label color_label = new Label();
                    color_label.Text = color + "  ";
                    color_label.Attributes.Add("style", "left: 1000px; position: absolute;");
                    form1.Controls.Add(color_label);


                    Label rate_label = new Label();
                    rate_label.Text = rate + "    ";
                    rate_label.Attributes.Add("style", "left: 1080px; position: absolute;");
                    form1.Controls.Add(rate_label);

                    if (available == true)
                    {

                        Button available_Button = new Button();
                        available_Button.ID = "" + serial_no;
                        available_Button.Text = "Add item " + serial_no + " to cart";
                        available_Button.Attributes.Add("style", "left: 1150px; position: absolute;");
                        available_Button.Click += new System.EventHandler(this.addToCart);
                        form1.Controls.Add(available_Button);

                    }
                    else
                    {
                        Label available_label = new Label();
                        available_label.Text = "The product is not available  ";
                        available_label.Attributes.Add("style", "left: 1150px; position: absolute;");
                        form1.Controls.Add(available_label);
                    }

                    Button wishList_Button = new Button();
                    wishList_Button.CommandName = "" + serial_no;
                    wishList_Button.Text = "Add item " + serial_no + " to a wishlist";
                    wishList_Button.Attributes.Add("style", "left: 1350px; position: absolute;");
                    wishList_Button.Click += new System.EventHandler(this.addToWishList);
                    form1.Controls.Add(wishList_Button);

                    newLine = new Label();
                    newLine.Text = ("</br> </br>");
                    form1.Controls.Add(newLine);
                }
               
            } 
        }
 
        protected void addToWishList(object sender, EventArgs e)
        {
            Button b = (Button)sender;
           int serial_no = Int32.Parse(b.CommandName);
            Session["serial_no"] = serial_no;
            Response.Redirect("AddToWishList.aspx");

        }
        protected void addToCart(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int serial_no = Int32.Parse(b.ID);

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("addToCart", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string username = (String)Session["username"];
            cmd.Parameters.Add(new SqlParameter("@serial", serial_no));
            cmd.Parameters.Add(new SqlParameter("@customername", username));
             try
            {
                //Executing the SQLCommand
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Successfully Added to the cart')</script>");
            }
            catch (SqlException)
            {
                Response.Write("<script>alert('Failed to add the product to the cart')</script>");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}