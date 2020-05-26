using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Logic;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if(ModelState.IsValid)
            {
                // pārbaudes - vai paroles sakrīt?
                // vai lietotājs ar e-pastu jau neeksistē?
                if(model.Password != model.PasswordRepeat)
                {
                    ModelState.AddModelError("pass", "Passwords do not match!");
                }
                else
                {
                    UserModel user = UserManager.GetByEmail(model.Email).ToModel();

                    if(user != null)
                    {
                        ModelState.AddModelError("mail", "User with this e-mail already exists!");
                    }
                    else
                    {
                        UserManager.Create(model.Email, model.Name, model.Password);

                        return RedirectToAction(nameof(SignIn));
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                UserModel user = UserManager.GetByEmailAndPassword(model.Email, model.Password).ToModel();

                if(user == null)
                {
                    ModelState.AddModelError("user", "Invalid e-mail/password!");
                }
                else
                {
                    HttpContext.Session.SetUserName(user.Name);
                    HttpContext.Session.SetUserId(user.Id);
                    HttpContext.Session.SetIsAdmin(user.IsAdmin);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult MyCart()
        {
            var userCart = UserCartManager.GetByUser(HttpContext.Session.GetUserId());
            // attēlošanai nepieciešamas tikai preces
            var items = userCart.Select(c => c.Item.ToModel()).ToList();
            return View(items);
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}