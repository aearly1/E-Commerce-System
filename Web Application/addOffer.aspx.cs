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
    public partial class addOffer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("log_in.aspx");
            }
        }
        protected void OfferAdding(object sender, EventArgs e) {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("addOffer", connection);
            command.CommandType = CommandType.StoredProcedure;
            try { 
            int offeramount = int.Parse(Offer_Amount_txt.Text);
            DateTime expirydate = DateTime.Parse(Expiry_date_txt.Text);

            command.Parameters.Add(new SqlParameter("@offeramount", offeramount));
            command.Parameters.Add(new SqlParameter("@expiry_date", expirydate));

           
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Offer added');</script>");
                Response.Write("<script>location.href='addOffer.aspx'</script>");
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Number);
                Response.Write("<script>alert('Failed to add offer');</script>");
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Failed to add offer')</script>");
            }
        }
        protected void redirectToVendorHome(object sender, EventArgs e)
        {
            Response.Redirect("VendorHome.aspx");
        }
    }
}