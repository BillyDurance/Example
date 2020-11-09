using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Online_Grocery_List_Application.Models
{
    public class GroceryList
    {
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Location")]
        public string location { get; set; }

        public string email { get; set; }

        [Display(Name = "Date Updated")]
        public DateTime dateUpdated { get; set; }

        //public Dictionary<int, string> itemsDict { get; set; }

        //public Dictionary<int, int> qytDict { get; set; }

        public GroceryList(string title, string location, string email, DateTime dateUpdated)
        {
            this.title = title;
            this.location = location;
            this.email = email;
            this.dateUpdated = dateUpdated;
        }
    }
}
