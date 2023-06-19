using KpopZstation.Handler;
using KpopZstation.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Controller
{
    public class CustomerController
    {
        public static bool validateRegister(Register view, string name, string email, string gender, string address, string password)
        {
            if(name.Trim().Equals("") || name.Trim().Length < 5 || name.Trim().Length > 50)
            {
                view.ErrorMessage = "Name must be filled and between 5 and 50 characters";
                return false;
            }
            if(email.Trim().Equals("") || !CustomerHandler.isEmailUnique(email))
            {
                view.ErrorMessage = "Email must be filled and unique among the customer’s email";
                return false;
            }
            if(gender.Equals(""))
            {
                view.ErrorMessage = "Gender must be selected";
                return false;
            }
            if(address.Trim().Equals("") || !address.EndsWith("Street"))
            {
                view.ErrorMessage = "Address ust be filled and ends with ‘Street’";
                return false;
            }
            if(password.Trim().Equals("") || !ValidateAlphanumeric(password))
            {
                view.ErrorMessage = "Password must be filled and alphanumeric";
                return false;
            }

            return CustomerHandler.registerCustomer(name, email, gender, address, password);
        }

        public static bool validateLogin(Login view, string email, string password, bool isRemember)
        {
            if (email.Trim().Equals(""))
            {
                view.ErrorMessage = "Email must be filled";
                return false;
            }
            if (password.Trim().Equals(""))
            {
                view.ErrorMessage = "Password must be filled";
                return false;
            }

            if(!CustomerHandler.loginCustomer(email, password, isRemember))
            {
                view.ErrorMessage = "Incorrect email or password!";
                return false;
            }

            return true;
        }

        public static bool validateUpdateProfile(UpdateProfile view, int id, string name, string email, string gender, string address, string password)
        {
            if (name.Trim().Equals("") || name.Trim().Length < 5 || name.Trim().Length > 50)
            {
                view.ErrorMessage = "Name must be filled and between 5 and 50 characters";
                return false;
            }
            if (email.Trim().Equals("") || !CustomerHandler.isEmailUnique(email))
            {
                view.ErrorMessage = "Email must be filled and unique among the customer’s email";
                return false;
            }
            if (gender.Equals(""))
            {
                view.ErrorMessage = "Gender must be selected";
                return false;
            }
            if (address.Trim().Equals("") || !address.EndsWith("Street"))
            {
                view.ErrorMessage = "Address ust be filled and ends with ‘Street’";
                return false;
            }
            if (password.Trim().Equals("") || !ValidateAlphanumeric(password))
            {
                view.ErrorMessage = "Password must be filled and alphanumeric";
                return false;
            }

            return CustomerHandler.updateCustomer(id, name, email, gender, address, password);
        }

        private static bool ValidateAlphanumeric(string input)
        {
            bool hasAlpha = false;
            bool hasNumeric = false;

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    hasAlpha = true;
                }
                else if (char.IsDigit(c))
                {
                    hasNumeric = true;
                }

                if (hasAlpha && hasNumeric)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool validateDeleteAccount(int userId)
        {
            return CustomerHandler.deleteAccount(userId);
        }
    }
}