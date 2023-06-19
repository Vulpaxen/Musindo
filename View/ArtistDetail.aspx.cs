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
    public partial class ArtistDetail : System.Web.UI.Page
    {
        public Customer customer;
        public Artist CurrArt;

        AlbumController albController = new AlbumController();
        ArtistController artController = new ArtistController();
        protected void Page_Load(object sender, EventArgs e)
        {
            customer = ((Customer)Session["customer"]);
            if (customer == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }

            if (!IsPostBack)
            {
                if(Request.QueryString["art_id"] == null)
                {
                    Response.Redirect("~/View/Home.aspx");
                }
                int id = Convert.ToInt32(Request.QueryString["art_id"]);

                // manual artist id
                CurrArt = artController.GetArtistByArtistID(id);
                imgArtist.ImageUrl = ResolveUrl("~/Assets/Artists/" + CurrArt.ArtistImage);

                List<Album> albums = albController.GetAllAlbumsByArtistID(id);

                rptAlbum.DataSource = albums;
                rptAlbum.DataBind();
            }
        }

        protected void rptAlbum_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "detail")
            {
                Response.Redirect("~/View/AlbumDetail.aspx?alb_id=" + id);
            }

            if (e.CommandName == "update")
            {
                Response.Redirect("~/View/UpdateAlbum.aspx?alb_id=" + id);
            }

            if (e.CommandName == "delete")
            {
                albController.DeleteAlbum(id);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnInsertAlbum_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["art_id"]);
            Response.Redirect("~/View/InsertAlbum.aspx?art_id=" + id);
        }
    }
}