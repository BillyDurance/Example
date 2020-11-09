using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _361Example.Data;
using System.Text.RegularExpressions;

namespace _361Example.Controllers
{
  
    public class UserContoller 
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

        //[HttpGet]
        //public static void CheckUserInDB()
        //{

        //}

    }
}
