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
    public partial class UpdateArtist : System.Web.UI.Page
    {
        Customer customer;
        ArtistController controller = new ArtistController();
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

            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["art_id"]);
                Artist CurrArtist = controller.GetArtistByArtistID(id);
                tbArtName.Text = CurrArtist.ArtistName;
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

        protected void btnUpdateArtist_Click(object sender, EventArgs e)
        {
            int ArtistID = Convert.ToInt32(Request.QueryString["art_id"]);
            
            if (controller.UpdateArtist(this, ArtistID, tbArtName.Text, upImage))
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }
    }
}