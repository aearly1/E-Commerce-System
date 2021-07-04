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
    public partial class vendorviewProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("log_in.aspx");
            }
            else
            {
                string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand cmd = new SqlCommand("vendorviewProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@vendorname", (string)Session["username"]));
                conn.Open();

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    int serial_no = rdr.GetInt32(rdr.GetOrdinal("serial_no"));
                    string productname = rdr.GetString(rdr.GetOrdinal("product_name"));
                    string category = rdr.GetString(rdr.GetOrdinal("category"));
                    string productdescription = rdr.GetString(rdr.GetOrdinal("product_description"));
                    decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                    decimal final_price = rdr.GetDecimal(rdr.GetOrdinal("final_price"));
                    string color = rdr.GetString(rdr.GetOrdinal("color"));
                    //int flag = rdr.GetOrdinal("rate");
                    int rate;
                    if (!(rdr.IsDBNull(rdr.GetOrdinal("rate")))){
                        rate = rdr.GetInt32(rdr.GetOrdinal("rate"));
                    }
                    else
                    {
                        rate = 0;
                    }
                    Label product_serial_label = new Label();
                    product_serial_label.Text = "(" + serial_no + ")  ";
                    form1.Controls.Add(product_serial_label);

                    Label product_name_label = new Label();
                    product_name_label.Text = "Product name: " + productname + "  ";
                    form1.Controls.Add(product_name_label);

                    Label category_label = new Label();
                    category_label.Text = "Category: " + category + "  ";
                    form1.Controls.Add(category_label);

                    Label product_description_label = new Label();
                    product_description_label.Text = "Description: " + productdescription + "  ";
                    form1.Controls.Add(product_description_label);

                    Label price_label = new Label();
                    price_label.Text = "Price: " + price + "  ";
                    form1.Controls.Add(price_label);

                    Label final_price_label = new Label();
                    final_price_label.Text = "Final price: " + final_price + "  ";
                    form1.Controls.Add(final_price_label);

                    Label color_label = new Label();
                    color_label.Text = "Color: " + color + "  ";
                    form1.Controls.Add(color_label);

                    Label rate_label = new Label();
                    rate_label.Text = "Rate: " + rate + "    ";
                    form1.Controls.Add(rate_label);

                    Button checkofferbutton = new Button();
                    checkofferbutton.CommandName = "" + serial_no;
                    checkofferbutton.Text = "Check for available offers";
                    checkofferbutton.Click += new System.EventHandler(this.OfferChecking);
                    form1.Controls.Add(checkofferbutton);

                    Button deleteproductbutton = new Button();
                    deleteproductbutton.CommandName = "" + serial_no;
                    deleteproductbutton.Text = "Delete product";
                    deleteproductbutton.Click += new System.EventHandler(this.Productdeleting);
                    form1.Controls.Add(deleteproductbutton);

                    Button editproductbutton = new Button();
                    editproductbutton.CommandName = "" + serial_no;
                    editproductbutton.Text = "Edit product";
                    editproductbutton.Click += new System.EventHandler(this.redirecttoEditProduct);
                    form1.Controls.Add(editproductbutton);

                    Label newLine = new Label();
                    newLine.Text = ("</br> </br>");
                    form1.Controls.Add(newLine);
                }
                Button homeredirectorbutton = new Button();
                homeredirectorbutton.Text = "Home";
                homeredirectorbutton.Click += new System.EventHandler(this.redirectToVendorHome);
                form1.Controls.Add(homeredirectorbutton);
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void redirectToVendorHome(object sender, EventArgs e)
        {
            Response.Redirect("VendorHome.aspx");
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void OfferChecking(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int serial_no = Int32.Parse(b.CommandName);
            Session["serial"] = serial_no; 
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("checkOfferonProduct", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@serial", serial_no));

            SqlParameter activeofferchecker = command.Parameters.Add("@activeoffer", SqlDbType.Bit);
            activeofferchecker.Direction = ParameterDirection.Output;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                if (activeofferchecker.Value.ToString().Equals("True")){
                    Response.Write("<script>alert('There's an offer on this product')</script>");
                }
                else{
                    Response.Write("<script>alert('There is no offer on this product')</script>");
                }
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Number);
                Response.Write("<script>alert('Failed to check offer');</script>");
            }
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void Productdeleting(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int serial_no = Int32.Parse(b.CommandName);
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("deleteProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
            string vendor_username = (String)Session["username"];

            command.Parameters.Add(new SqlParameter("@vendorname", vendor_username));
            command.Parameters.Add(new SqlParameter("@serialnumber", serial_no));

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Product successfully deleted');</script>");
                Response.Write("<script>location.href='vendorviewProducts.aspx'</script>");
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Number);
                Response.Write("<script>alert('Failed to delete product');</script>");
            }
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void redirecttoEditProduct(object sender, EventArgs e) {
            Button b = (Button)sender;
            int serial_no = Int32.Parse(b.CommandName);
            Session["serial"] = serial_no;
            Response.Redirect("EditProduct.aspx");
        }
    }
}