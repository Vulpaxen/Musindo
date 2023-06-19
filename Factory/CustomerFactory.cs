using KpopZstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Factory
{
    public class CustomerFactory
    {
        public static Customer createCustomer(string name, string email, string gender, string address, string password)
        {
            Customer c = new Customer();
            c.CustomerName = name;
            c.CustomerEmail = email;
            c.CustomerGender = gender;
            c.CustomerAddress = address;
            c.CustomerPassword = password;
            c.CustomerRole = "user";

            return c;
        }
    }
}