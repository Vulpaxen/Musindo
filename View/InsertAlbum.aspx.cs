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
    public partial class InsertAlbum : System.Web.UI.Page
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
            if (Request.QueryString["art_id"] == null)
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

        protected void btnSubmitAlbum_Click(object sender, EventArgs e)
        {            
            AlbumController validator = new AlbumController();
            int id = Convert.ToInt32(Request.QueryString["art_id"]);
            Album album = validator.InsertAlbum(this, id, tbAlbName.Text, tbAlbDesc.Text, tbAlbPrice.Text, tbAlbStock.Text, upImage);

            if (album != null)
            {
                Response.Redirect("ArtistDetail.aspx?art_id=" + id);
            }
        }
    }
}