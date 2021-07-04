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
    public partial class applyOffer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("log_in.aspx");
            }
        }
        protected void OfferApplying(object sender, EventArgs e) {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("applyOffer", connection);
            command.CommandType = CommandType.StoredProcedure;

            try { 
            string vendor_name = (String)Session["username"];
            int offerid = Int32.Parse(offer_id_txt.Text);
            int serial = Int32.Parse(serial_id_txt.Text);

            command.Parameters.Add(new SqlParameter("@vendorname", vendor_name));
            command.Parameters.Add(new SqlParameter("@offerid", offerid));
            command.Parameters.Add(new SqlParameter("@serial", serial));

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                
                Response.Write("<script>alert('Offer activated')</script>");
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Number);
                Response.Write("<script>alert('Failed to check offer');</script>");
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Failed to check offer')</script>");
            }

        }
        protected void redirectToVendorHome(object sender, EventArgs e)
        {
            Response.Redirect("VendorHome.aspx");
        }
    }
}