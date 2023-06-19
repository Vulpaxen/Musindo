using KpopZstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Repository
{
    public class DatabaseSingleton
    {
        private static KpopzstationDatabaseEntities db = null;

        private DatabaseSingleton()
        {

        }

        public static KpopzstationDatabaseEntities getInstance()
        {
            if (db == null)
            {
                db = new KpopzstationDatabaseEntities();
            }

            return db;
        }
    }
}