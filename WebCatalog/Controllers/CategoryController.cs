using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCatalog.Database;
using WebCatalog.Models;

namespace WebCatalog.Controllers
{
    public class CategoryController : Controller
    {
        public static List<CategoryModel> Categories = new List<CategoryModel>();

        // 1.a
        public IActionResult Index()
        {
            using(var db = new DB())
            {
                var model = db.Categories.OrderBy(c => c.Name)
                    .Select(c => new CategoryModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                    })
                    .ToList();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CategoryModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if(ModelState.IsValid)
            {
                // saglabāšana
                using(var db = new DB())
                {
                    db.Categories.Add(new Database.Categories()
                    {
                        Name = model.Name,
                    });
                    db.SaveChanges();
                }

                // pāreja uz sarakstu
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}