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
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("log_in.aspx");
            }
        }
        protected void ProductEditing(object sender, EventArgs e) {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("EditProduct", connection);
            command.CommandType = CommandType.StoredProcedure;

            string vendor_username = (String)Session["username"];
            int serial = (Int32)Session["serial"];
            string product_name = Product_name.Text;
            string category = Category.Text;
            string product_description = Product_description.Text;
            float price = float.Parse(Price.Text);
            string color = Color.Text;

            command.Parameters.Add(new SqlParameter("@vendorname", vendor_username));
            command.Parameters.Add(new SqlParameter("@serialnumber", serial));
            command.Parameters.Add(new SqlParameter("@product_name", product_name));
            command.Parameters.Add(new SqlParameter("@category", category));
            command.Parameters.Add(new SqlParameter("@product_description", product_description));
            command.Parameters.Add(new SqlParameter("@price", price));
            command.Parameters.Add(new SqlParameter("@color", color));

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Product successfully edited');</script>");
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Number);
                Response.Write("<script>alert('Failed to edit product');</script>");
            }
        }
        protected void redirectToVendorHome(object sender, EventArgs e)
        {
            Response.Redirect("VendorHome.aspx");
        }
    }
}