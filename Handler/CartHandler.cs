using KpopZstation.Model;
using KpopZstation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Handler
{
    public class CartHandler
    {
        public static int getAlbumStock( int albumId)
        {
            AlbumRepository repo = new AlbumRepository();
            Album album = repo.GetAlbumByID(albumId);

            if (album != null)
            {
                return album.AlbumStock;
            }

            return -1;
        }
        public static bool addToCart(int customerId, int albumId, int qty)
        {
            if(CartRepository.checkCartItem(customerId, albumId) == null)
            {
                if (CartRepository.addItemToCart(customerId, albumId, qty) != null)
                {
                    return true;
                }
            } else
            {
                if(CartRepository.updateCartItem(customerId, albumId, qty) != null)
                {
                    return true;
                }
            }

            return false;
        }

        public static List<Cart> getUserCart(int userId)
        {
            return CartRepository.getCartByCustomerId(userId);
        }

        public static bool removeItemFromCart(int userId, int albumId)
        {
            if (CartRepository.removeItemFromCart(userId, albumId) != null)
            {
                return true;
            }

            return false;
        }
    }
}