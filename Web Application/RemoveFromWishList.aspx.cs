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
    public partial class RemoveFromWishList : System.Web.UI.Page
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
                string username = (string)Session["username"];
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
                    wishList_Button.Text = "view content of " + wishList;
                    wishList_Button.Attributes.Add("style", "left: 300px; position: absolute;");
                    wishList_Button.Click += new System.EventHandler(this.removeFromWishList);
                    form1.Controls.Add(wishList_Button);

                    Label newLine = new Label();
                    newLine.Text = ("</br> </br>");
                    form1.Controls.Add(newLine);
                }

            }

        }
        protected void removeFromWishList(Object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string wishList = b.CommandName;
            Session["wishList"] = wishList;
            Response.Redirect("RemoveItem.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
   
}