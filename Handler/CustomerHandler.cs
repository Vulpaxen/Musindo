using KpopZstation.Model;
using KpopZstation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Handler
{
    public class CustomerHandler
    {
        public static bool isEmailUnique(string email)
        {
            if (CustomerRepository.getCustomerByEmail(email) != null)
            {
                return false;
            }

            return true;
        }

        public static bool registerCustomer(string name, string email, string gender, string address, string password)
        {
            return CustomerRepository.insertCustomer(name, email, gender, address, password);
        }

        public static bool loginCustomer(string email, string password, bool isRemember)
        {
            Customer c = CustomerRepository.login(email, password);
            if(c == null)
            {
                return false;
            }
            
            // set session
            HttpContextBase httpContext = new HttpContextWrapper(HttpContext.Current);
            httpContext.Session["customer"] = c;

            // set cookie
            if (isRemember)
            {
                HttpCookie cookie = new HttpCookie("customer_email");
                cookie.Value = c.CustomerEmail;
                cookie.Expires = DateTime.Now.AddDays(1);
                httpContext.Response.Cookies.Add(cookie);

                HttpCookie cookie2 = new HttpCookie("customer_password");
                cookie2.Value = c.CustomerPassword;
                cookie2.Expires = DateTime.Now.AddDays(1);
                httpContext.Response.Cookies.Add(cookie2);
            }

            return true;
        }

        public static bool updateCustomer(int id, string name, string email, string gender, string address, string password)
        {
            if(CustomerRepository.updateCustomer(id, name, email, gender, address, password) != null)
            {
                return true;
            }

            return false;
        }

        public static bool deleteAccount(int userId)
        {
            if (CustomerRepository.deleteAccount(userId) != null)
            {
                return true;
            }

            return false;
        }
    }
}