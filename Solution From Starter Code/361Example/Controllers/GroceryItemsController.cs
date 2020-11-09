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
  
    public class GroceryItemsController 
    {
        //Checks if a new or updating item is a valid entry.
        public static void ItemValidityCheck(string name, int quantity)
        {
            if (name == "" || quantity <=0)
            {
                throw new System.InvalidOperationException("Invalid data. Can not have null for a items name or the quantity to be zero or less.");
            }
        }

    }
}
