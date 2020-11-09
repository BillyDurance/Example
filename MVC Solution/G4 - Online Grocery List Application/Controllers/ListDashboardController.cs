using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Group4_Online_Grocery_List_Application.Controllers
{
    public class ListDashboardController : Controller
    {
        
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
        public IActionResult Edit(string email, string title)
        {
            ViewData["email"] = email;
            ViewData["listTitle"] = title;
           
            return View();
        }

        public IActionResult Delete(string title, string email)
        {
            return View();
        }


    }
}