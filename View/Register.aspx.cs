using KpopZstation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZstation.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                Response.Redirect("/");
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (CustomerController.validateRegister(this, tbName.Text, tbEmail.Text, ddlGender.SelectedValue, tbAddress.Text, tbPassword.Text))
            {
                Response.Redirect("~/View/Login.aspx");
            }
        }
    }
}