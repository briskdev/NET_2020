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
            // new line
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
            // grupējam pēc ItemId un skaitām, cik preces ir.
            var items = userCart.Select(c => c.Item.ToModel())
                .GroupBy(i => i.Id)
                .Select(g =>
                {
                    // grupas pirmais ieraksts ir - prece
                    // un skaits - cik šādu preču
                    var item = g.First();
                    item.Count = g.Count();

                    return item;
                }).ToList();
            
            return View(items);
        }

        public IActionResult Confirm()
        {
            // TODO: pārbaude, ka lietotājs ir pieslēdzies (autentificējies)
            UserCartManager.RemoveByUser(HttpContext.Session.GetUserId());
            TempData["message"] = "Your order has been successfully received!";

            return RedirectToAction(nameof(MyCart));
        }

        public IActionResult DeleteCartItem(int id)
        {
            // nepieciešams norādīt arī UserId no sesijas, lai nedzēstu cita lietotāja preces.
            UserCartManager.RemoveByItem(HttpContext.Session.GetUserId(), id);
            TempData["message"] = "Item removed!";

            return RedirectToAction(nameof(MyCart));
        }
    }
}