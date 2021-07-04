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
    public partial class RemoveFromCart : System.Web.UI.Page
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

                SqlCommand cmd = new SqlCommand("viewMyCart", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                string username = (string)Session["username"];
                cmd.Parameters.Add(new SqlParameter("@customer", username));

                conn.Open();

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
                product_name_header.Attributes.Add("style", "left: 360px; position: absolute;");
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
                addToCart_header.Text = "Remove ";
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

                    Button remove_Button = new Button();
                    remove_Button.CommandName = "" + serial_no;
                    remove_Button.Text = "Remove " + serial_no + " from the cart";
                    remove_Button.Attributes.Add("style", "left: 1150px; position: absolute;");
                    remove_Button.Click += new System.EventHandler(this.removeItem);
                    form1.Controls.Add(remove_Button);

                    newLine = new Label();
                    newLine.Text = ("</br> </br>");
                    form1.Controls.Add(newLine);
                }

            }

        }
        protected void removeItem(Object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("removefromCart", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string username = (string)Session["username"];
            int serial = Int32.Parse(b.CommandName);
            cmd.Parameters.Add(new SqlParameter("@customername", username));
            cmd.Parameters.Add(new SqlParameter("@serial", serial));
            Session.Remove("serial_no");

            try
            {
                //Executing the SQLCommand
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Successfully removed the item from the cart')</script>");
                Response.Write("<script>location.href='RemoveFromCart.aspx'</script>");

            }
            catch (SqlException)
            {
                Response.Write("<script>alert('Failed to remove the item')</script>");
                Response.Write("<script>location.href='RemoveFromCart.aspx'</script>");

            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}