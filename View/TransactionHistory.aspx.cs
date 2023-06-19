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
    public partial class TransactionHistory : System.Web.UI.Page
    {
        Customer customer;
        public List<TransactionHeader> transactions;
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

            transactions = TransactionController.getUserTransaction(customer.CustomerID);
        }
    }
}