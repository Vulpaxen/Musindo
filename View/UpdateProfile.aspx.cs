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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        int customerId;
        Customer c;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
            {
                Response.Redirect("~/View/Home.aspx");
            }

            c = (Customer)Session["customer"];
            customerId = Convert.ToInt32(c.CustomerID);
            if(!IsPostBack)
            {
                tbName.Text = c.CustomerName;
                tbEmail.Text = c.CustomerEmail;
                ddlGender.SelectedValue = c.CustomerGender;
                tbAddress.Text = c.CustomerAddress;
                tbPassword.Text = c.CustomerPassword;
            }
        }

        public string ErrorMessage
        {
            get { return lblError.Text; }
            set
            {
                lblError.Text = value;

                // Show Error Alert
                if (!string.IsNullOrEmpty(lblError.Text))
                {
                    alert.Style.Remove("display");
                }
                else
                {
                    alert.Style.Add("display", "none");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CustomerController.validateUpdateProfile(this, customerId, tbName.Text, tbEmail.Text, ddlGender.SelectedValue, tbAddress.Text, tbPassword.Text))
            {
                Response.Redirect("~/View/UpdateProfile.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(CustomerController.validateDeleteAccount(c.CustomerID))
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
}