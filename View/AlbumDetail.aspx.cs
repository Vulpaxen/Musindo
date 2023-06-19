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
    public partial class AlbumDetail : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                // manual artistID and albumID
                if (Request.QueryString["alb_id"] == null)
                {
                    Response.Redirect("~/View/Home.aspx");
                }
                int AlbumID = Convert.ToInt32(Request.QueryString["alb_id"]);

                Album CurrAlbum = controller.GetAlbumByAlbumID(AlbumID);
                AlbName.Text = CurrAlbum.Albumname;
                AlbImage.ImageUrl = ResolveUrl("~/Assets/Albums/" + CurrAlbum.AlbumImage);
                AlbDesc.Text = CurrAlbum.AlbumDescription;
                AlbPrice.Text = Convert.ToString(CurrAlbum.AlbumPrice);
                AlbStock.Text = Convert.ToString(CurrAlbum.AlbumStock);
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            tbQuantity.Text = controller.AddQuantity(tbQuantity.Text);
            btnAdd.Enabled = controller.AddButtonValidation(tbQuantity.Text, AlbStock.Text);
            btnRemove.Enabled = controller.RemoveButtonValidation(tbQuantity.Text);
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            tbQuantity.Text = controller.RemoveQuantity(tbQuantity.Text);
            btnAdd.Enabled = controller.AddButtonValidation(tbQuantity.Text, AlbStock.Text);
            btnRemove.Enabled = controller.RemoveButtonValidation(tbQuantity.Text);
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if(CartController.validateAlbum(this, customer.CustomerID, Request.QueryString["alb_id"], tbQuantity.Text))
            {
                Response.Redirect("~/View/MyCart.aspx");
            }
        }
    }
}