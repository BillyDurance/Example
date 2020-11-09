using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _361Example.Models
{
    public class GroceryList
    {
        public string title { get; set; }

        public string location { get; set; }

        public string email { get; set; }

        public DateTime dateUpdated { get; set; }

        public Dictionary<int, string> itemsDict { get; set; }

        public Dictionary<int, int> qytDict { get; set; }

    }
}