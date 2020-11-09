using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Group4_Online_Grocery_List_Application.Engine
{
    public class UserEngine
    {
        public static void EmailValidityCheck(string newEmail, string newPassword)
        {
            if (newEmail == "" || newPassword == "")
            {
                throw new System.InvalidOperationException("Invalid data. Can not have null as an email or password.");
            }

            //Check for bad email
            Regex rgx = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");

            if (!rgx.IsMatch(newEmail))
            {
                throw new System.InvalidOperationException("Invalid data. Not a valid email.");
            }

        }
    }
}
