using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mashroo3Qa3edetTa5zeenMa3loomat
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("log_in.aspx");
            }
            else if ((int) Session["type"] != 0)
            {
                Session.Abandon();
                Response.Redirect("log_in.aspx");
            }
        } 
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add PhoneNumber.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCreditCard.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProducts.aspx");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddWishList.aspx");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("RemoveFromCart.aspx");
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("RemoveFromWishList.aspx");
        }
        protected void Orders(object sender, EventArgs e)
        {
            Response.Redirect("Orders.aspx");
        }
    }
}