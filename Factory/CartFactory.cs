using KpopZstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Factory
{
    public class CartFactory
    {
        public static Cart createItem(int customerId, int albumId, int qty)
        {
            Cart c = new Cart();
            c.CustomerID = customerId;
            c.AlbumID = albumId;
            c.Qty = qty;

            return c;
        }
    }
}