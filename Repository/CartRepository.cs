using KpopZstation.Factory;
using KpopZstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Repository
{
    public class CartRepository
    {
        private static KpopzstationDatabaseEntities db = DatabaseSingleton.getInstance();

        public static Cart checkCartItem(int customerId, int albumId)
        {
            return (from c in db.Carts where c.CustomerID == customerId && c.AlbumID == albumId select c).FirstOrDefault();
        }
        public static Cart addItemToCart(int customerId, int albumId, int qty)
        {
            Cart c = CartFactory.createItem(customerId, albumId, qty);
            db.Carts.Add(c);
            db.SaveChanges();

            return c;
        }
        public static Cart updateCartItem(int customerId, int albumId, int qty)
        {
            Cart item = (from c in db.Carts where c.CustomerID == customerId && c.AlbumID == albumId select c).FirstOrDefault();
            item.Qty = qty;
            db.SaveChanges();

            return item;
        }
        public static List<Cart> getCartByCustomerId(int userId)
        {
            return (from c in db.Carts where c.CustomerID == userId select c).ToList();
        }

        public static Cart removeItemFromCart(int userId, int albumId)
        {
            Cart item =  (from c in db.Carts where c.CustomerID == userId && c.AlbumID == albumId select c).FirstOrDefault();
            db.Carts.Remove(item);
            db.SaveChanges();

            return item;
        }
    }
}