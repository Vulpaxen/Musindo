using KpopZstation.Handler;
using KpopZstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Controller
{
    public class TransactionController
    {
        public static bool checkout(int userId)
        {
            return TransactionHandler.checkout(userId);
        }

        public static List<TransactionHeader> getUserTransaction(int userId)
        {
            return TransactionHandler.getUserTransaction(userId);
        }
    }
}