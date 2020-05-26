using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWeb.Logic;
using FirstWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWeb.Controllers
{
    public class UserController : Controller
    {
        // https://localhost:44304/User/Index
        // https://localhost:44304/User/
        public IActionResult Index()
        {
            // select Id, Name, Email, Phone from Users
            var users = UserManager.GetAll().Select(u => u.ToModel()).ToList();

            users = null;
            users = users.ToList();
            
            return View(users);
        }

        // https://localhost:44304/User/View/2
        public IActionResult View(int id)
        {
            // select Id, Name, Email, Phone from Users where Id = @id
            var user = UserManager.Get(id).ToModel();

            return View(user);
        }

        // https://localhost:44304/User/Add
        [HttpGet]
        public IActionResult Add()
        {
            var user = new UserModel();
            return View(user);
        }

        [HttpPost]
        public IActionResult Add(UserModel model)
        {
            if(ModelState.IsValid)
            {
                // VISS OK - modelis ir valīds, var veikt datu saglabāšanu
                // insert into Users(Email, Phone, Name)
                // values(@email, @phone, @name)
                // COMMIT;
                UserManager.Create(model.Name, model.Email, model.Phone);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}