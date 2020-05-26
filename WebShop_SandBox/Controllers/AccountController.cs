using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebShop_SandBox.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            ViewData["Title"] = "Sign up";
            return View();
        }

        public IActionResult SignIn()
        {
            ViewData["Title"] = "Sign in";
            return View("Demo");
        }

        public IActionResult MyCart()
        {
            ViewData["Title"] = "My cart";
            return View("Demo");
        }
    }
}