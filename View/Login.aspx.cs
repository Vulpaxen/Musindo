using KpopZstation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZstation.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                Response.Redirect("/");
            }

            cbRemember.InputAttributes["class"] = "form-check-input";

            if(!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["customer_email"];
                string email = cookie != null ? cookie.Value : null;

                HttpCookie cookie2 = Request.Cookies["customer_password"];
                string password = cookie2 != null ? cookie2.Value : null;

                if(email != null && password != null)
                {
                    tbEmail.Text = email;
                    tbPassword.Text = password;

                    if (CustomerController.validateLogin(this, tbEmail.Text, tbPassword.Text, false))
                    {
                        Response.Redirect("~/View/Home.aspx");
                    } else
                    {
                        ErrorMessage = "Cookie expired! please enter your credentials";

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

                        tbEmail.Text = "";
                        tbPassword.Text = "";
                    }
                }
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (CustomerController.validateLogin(this, tbEmail.Text, tbPassword.Text, cbRemember.Checked))
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }
    }
}