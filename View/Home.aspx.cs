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
    public partial class Home : System.Web.UI.Page
    {
        public List<Artist> Artists;
        public Customer customer;

        ArtistController artController = new ArtistController();
        protected void Page_Load(object sender, EventArgs e)
        {
            customer = ((Customer)Session["customer"]);

            if (!IsPostBack)
            {
                Artists = artController.GetAllArtists();
                rptArtists.DataSource = Artists;
                rptArtists.DataBind();
            }
        }

        protected void btnInsertArtist_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertArtist.aspx");
        }

        protected void rptArtists_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "detail")
            {
                Response.Redirect("~/View/ArtistDetail.aspx?art_id=" + id);
            }

            if (e.CommandName == "update")
            {
                Response.Redirect("~/View/UpdateArtist.aspx?art_id=" + id);
            }

            if (e.CommandName == "delete")
            {
                artController.DeleteArtist(id);
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}