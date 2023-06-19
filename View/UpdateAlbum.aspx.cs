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
    public partial class UpdateAlbum : System.Web.UI.Page
    {
        public Customer customer;
        AlbumController controller = new AlbumController();
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
            if (Request.QueryString["alb_id"] == null)
            {
                Response.Redirect("~/View/Home.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["alb_id"] == null)
                {
                    Response.Redirect("~/View/Home.aspx");
                }
                int id = Convert.ToInt32(Request.QueryString["alb_id"]);

                Album CurrAlbum = controller.GetAlbumByAlbumID(id);
                tbAlbName.Text = CurrAlbum.Albumname;
                tbAlbDesc.Text = CurrAlbum.AlbumDescription;
                tbAlbPrice.Text = Convert.ToString(CurrAlbum.AlbumPrice);
                tbAlbStock.Text = Convert.ToString(CurrAlbum.AlbumStock);
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

        protected void btnUpdateAlbum_Click(object sender, EventArgs e)
        {
            int AlbumID = Convert.ToInt32(Request.QueryString["alb_id"]);
            Album album = controller.UpdateAlbum(this, AlbumID, tbAlbName.Text, tbAlbDesc.Text, tbAlbPrice.Text, tbAlbStock.Text, upImage);

            if (album != null)
            {
                Response.Redirect("ArtistDetail.aspx?art_id=" + album.ArtistID);
            }
        }
    }
}