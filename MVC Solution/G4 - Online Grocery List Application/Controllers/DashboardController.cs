﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Group4_Online_Grocery_List_Application.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string title)
        {
            if (title == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "ListDashboardController");
        }
    }
}
