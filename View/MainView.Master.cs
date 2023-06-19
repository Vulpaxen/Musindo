using KpopZstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZstation.View
{
    public partial class MainView : System.Web.UI.MasterPage
    {
        public Customer customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            customer = ((Customer)Session["customer"]);
        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Register.aspx");
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login.aspx");
        }

        protected void btHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void btCartC_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MyCart.aspx");
        }

        protected void btTransactionC_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionHistory.aspx");
        }

        protected void btUpdateC_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/UpdateProfile.aspx");
        }

        protected void btnTransactionAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionReport.aspx");
        }

        protected void btLogoutC_Click(object sender, EventArgs e)
        {
            Session.Remove("customer");
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            // reset cookie
            HttpContext.Current.Response.Cookies.Remove("customer_email");
            HttpCookie savedookie = HttpContext.Current.Request.Cookies["customer_email"];
            if (savedookie != null)
            {
                savedookie.Expires = DateTime.Now.AddDays(-10);
                savedookie.Value = null;
                HttpContext.Current.Response.SetCookie(savedookie);
            }
            HttpContext.Current.Response.Cookies.Remove("customer_password");
            HttpCookie savedookie2 = HttpContext.Current.Request.Cookies["customer_password"];
            if (savedookie2 != null)
            {
                savedookie2.Expires = DateTime.Now.AddDays(-10);
                savedookie2.Value = null;
                HttpContext.Current.Response.SetCookie(savedookie2);
            }

            Response.Redirect("~/View/Login.aspx");
        }
    }
}