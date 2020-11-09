using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _361Example.Models;

namespace groceryListNS
{
    public class GroceryListEngine
    {

        public static void EmailCheck(int databaseID, string newEmail, string newPassword)
        {
            if (newEmail == "")
            {
                throw new System.InvalidOperationException("Invalid data. Can not null as a email.");
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