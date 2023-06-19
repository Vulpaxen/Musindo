using KpopZstation.Factory;
using KpopZstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Repository
{
    public class TransactionRepository
    {
        private static KpopzstationDatabaseEntities db = DatabaseSingleton.getInstance();
        public static TransactionHeader checkout(int userId)
        {
            List<Cart> items = (from c in db.Carts where c.CustomerID == userId select c).ToList();

            TransactionHeader th = TransactionFactory.createTransactionHeader(userId);
            db.TransactionHeaders.Add(th);

            foreach(var item in items)
            {
                TransactionDetail td = TransactionFactory.createTransactionDetail(th.TransactionID, item.AlbumID, item.Qty);
                db.TransactionDetails.Add(td);

                db.Carts.Remove(item);
            }

            db.SaveChanges();

            return th;
        }

        public static List<TransactionHeader> getUserTransaction(int userId)
        {
            return (from th in db.TransactionHeaders where th.CustomerID == userId select th).ToList();
        }

        public static List<TransactionHeader> getTransactions()
        {
            return db.TransactionHeaders.ToList();
        }
    }
}