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
    public partial class viewQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("log_in.aspx");
            }
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("viewQuestions", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string vendor_username = (String)Session["username"];
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@vendorname", vendor_username));
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                int serial_no = rdr.GetInt32(rdr.GetOrdinal("serial_no"));
                string customername = rdr.GetString(rdr.GetOrdinal("customer_name"));
                string question = rdr.GetString(rdr.GetOrdinal("question"));
                string answer = rdr.GetString(rdr.GetOrdinal("answer"));

                Label customer_name_label = new Label();
                customer_name_label.Text = "Customer " + customername + " asked: ";
                form1.Controls.Add(customer_name_label);

                Label question_label = new Label();
                question_label.Text = question;
                form1.Controls.Add(question_label);

                Label newLine1 = new Label();
                newLine1.Text = ("</br> </br>");
                form1.Controls.Add(newLine1);

                Label answer_label = new Label();
                answer_label.Text = "You answered: " + answer + " ";
                form1.Controls.Add(answer_label);

                Button answerquestionbutton = new Button();
                answerquestionbutton.ID = "" + serial_no;
                answerquestionbutton.Text = "Answer this question";
                answerquestionbutton.Click += new System.EventHandler(this.redirecttoanswerquestions);
                form1.Controls.Add(answerquestionbutton);

                Label newLine2 = new Label();
                newLine2.Text = ("</br> </br>");
                form1.Controls.Add(newLine2);

            }
            Button homeredirectorbutton = new Button();
            homeredirectorbutton.Text = "Home";
            homeredirectorbutton.Click += new System.EventHandler(this.redirectToVendorHome);
            form1.Controls.Add(homeredirectorbutton);
        }
        protected void redirectToVendorHome(object sender, EventArgs e)
        {
            Response.Redirect("VendorHome.aspx");
        }
        protected void redirecttoanswerquestions(object sender, EventArgs e) {
            Button b = (Button)sender;
            int serial_no = Int32.Parse(b.ID);
            String name = b.CommandName;
            Session["serial"] = serial_no;
            Session["customername"] = name;
            Response.Redirect("answerQuestions.aspx");
        }
    }
}