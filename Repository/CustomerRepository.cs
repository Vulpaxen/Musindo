using KpopZstation.Factory;
using KpopZstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Repository
{
    public class CustomerRepository
    {
        private static KpopzstationDatabaseEntities db = DatabaseSingleton.getInstance();
        public static bool insertCustomer(string name, string email, string gender, string address, string password)
        {
            Customer newCustomer = CustomerFactory.createCustomer(name, email, gender, address, password);
            db.Customers.Add(newCustomer);
            db.SaveChanges();

            return true;
        }

        public static Customer getCustomerByEmail(string email)
        {
           return (from c in db.Customers where c.CustomerEmail.Equals(email) select c).FirstOrDefault();
        }

        public static Customer login(string email, string password)
        {
            return (from c in db.Customers where c.CustomerEmail.Equals(email) && c.CustomerPassword.Equals(password) select c).FirstOrDefault();
        }

        public static Customer updateCustomer(int id, string name, string email, string gender, string address, string password)
        {
            Customer c = db.Customers.Find(id);
            c.CustomerName = name;
            c.CustomerEmail = email;
            c.CustomerGender = gender;
            c.CustomerAddress = address;
            c.CustomerPassword = password;
            db.SaveChanges();

            return c;
        }

        public static Customer deleteAccount(int userId)
        {
            Customer c = db.Customers.Find(userId);
            db.Customers.Remove(c);
            db.SaveChanges();

            return c;
        }
    }
}