using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Online_Grocery_List_Application.Models
{
    public class GroceryItem
    {
        [Display(Name = "Name")]

        public string itemName { get; set; }

        [Display(Name = "Quanity")]
        public int quanity { get; set; }

        public GroceryItem (string name, int quanity)
        {
            this.itemName = name;
            this.quanity = quanity;
        }
    }
}
