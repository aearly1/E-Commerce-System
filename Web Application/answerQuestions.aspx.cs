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
    public partial class answerQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("log_in.aspx");
            }
        }
        protected void QuestionAnswering(object sender, EventArgs e){
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("answerQuestions", connection);
            command.CommandType = CommandType.StoredProcedure;

            string vendor_username = (String)Session["username"];
            int serial = int.Parse((String)Session["serial"]);
            string customer_username = (String)Session["customername"];
            string answer = Answer_txt.Text;

            command.Parameters.Add(new SqlParameter("@vendorUsername", vendor_username));
            command.Parameters.Add(new SqlParameter("@serialno", serial));
            command.Parameters.Add(new SqlParameter("@customername", customer_username));
            command.Parameters.Add(new SqlParameter("@answer", answer));

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Answer uploaded');</script>");
                Session["serial"] = null;
                Session["customername"] = null;
                Response.Write("<script>location.href='viewQuestions.aspx'</script>");
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Number);
                Response.Write("<script>alert('Failed to upload answer');</script>");
            }
        }
    }
}