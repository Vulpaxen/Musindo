using KpopZstation.Controller;
using KpopZstation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace KpopZstation.View
{
    public partial class InsertArtist : System.Web.UI.Page
    {
        Customer customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            customer = ((Customer)Session["customer"]);

            if (customer == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }
            if (!customer.CustomerRole.Equals("admin"))
            {
                Response.Redirect("~/View/Home.aspx");
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

        protected void btnSubmitArtist_Click(object sender, EventArgs e)
        {
            ArtistController validator = new ArtistController();

            if (validator.InsertArtist(this, tbArtName.Text, upImage))
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }
    }
}