using KpopZstation.Handler;
using KpopZstation.Model;
using KpopZstation.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Controller
{
    public class CartController
    {
        public static bool validateAlbum(AlbumDetail view, int customerId, string albumId, string quantity)
        {
            var isAlbumNumeric = int.TryParse(albumId, out int album);
            if (!isAlbumNumeric)
            {
                HttpContext.Current.Response.Redirect("~/View/Home.aspx");
                return false;
            }

            var isQtyNumeric = int.TryParse(quantity, out int qty);
            if (!isQtyNumeric)
            {
                view.ErrorMessage = "Quantity must be filled and numeric";
                return false;
            }

            if (qty < 1)
            {
                view.ErrorMessage = "Quantity must more than 0";
                return false;
            }

            if (qty > CartHandler.getAlbumStock(album))
            {
                view.ErrorMessage = "Quantity can’t be more than the stock album";
                return false;
            }

            return CartHandler.addToCart(customerId, album, qty);
        }

        public static List<Cart> getUserCart(int userId)
        {
            return CartHandler.getUserCart(userId);
        }

        public static bool removeItem(int userId, int albumId)
        {
            return CartHandler.removeItemFromCart(userId, albumId);
        }
    }
}