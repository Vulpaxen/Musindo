using KpopZstation.Controller;
using KpopZstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZstation.View
{
    public partial class MyCart : System.Web.UI.Page
    {
        Customer customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            customer = ((Customer)Session["customer"]);
            if (customer == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }
            if (!customer.CustomerRole.Equals("user"))
            {
                Response.Redirect("~/View/Home.aspx");
            }

            rptCart.DataSource = CartController.getUserCart(customer.CustomerID);
            rptCart.DataBind();
        }

        protected void rptCart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int albumId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Remove")
            {
                if(CartController.removeItem(customer.CustomerID, albumId))
                {
                    Response.Redirect(Request.RawUrl);
                }
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if(TransactionController.checkout(customer.CustomerID))
            {
                Response.Redirect("~/View/TransactionHistory.aspx");
            }
        }
    }
}