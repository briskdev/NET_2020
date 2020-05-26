using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebShop_SandBox.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index(int id)
        {
            ViewData["Title"] = "Category";
            return View("Demo");
        }

        public IActionResult Buy(int id)
        {
            ViewData["Title"] = "Add to cart";
            return View("Demo");
        }
    }
}