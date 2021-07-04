using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mashroo3Qa3edetTa5zeenMa3loomat
{
    public partial class VendorHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("log_in.aspx");
            }
        }
        protected void redirectToPostProduct(object sender, EventArgs e) 
        {
            Response.Redirect("postProduct.aspx");
        }
        protected void redirectToVendorViewProducts(object sender, EventArgs e)
        {
            Response.Redirect("vendorviewProducts.aspx");
        }
        protected void redirectToViewQuestions(object sender, EventArgs e)
        {
            Response.Redirect("viewQuestions.aspx");
        }
        protected void redirectToAddOffer(object sender, EventArgs e)
        {
            Response.Redirect("addOffer.aspx");
        }
        protected void redirectToCheckAndRemove(object sender, EventArgs e)
        {
            Response.Redirect("checkandremoveExpiredoffer.aspx");
        }
        protected void redirectToofferApplying(object sender, EventArgs e)
        {
            Response.Redirect("applyOffer.aspx");
        }

    }
}