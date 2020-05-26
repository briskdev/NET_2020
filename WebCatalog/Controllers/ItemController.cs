using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCatalog.Database;
using WebCatalog.Models;

namespace WebCatalog.Controllers
{
    public class ItemController : Controller
    {
        public static List<ItemModel> Items = new List<ItemModel>();

        // id -> kategorijas ID
        public IActionResult Index(int? id)
        {
            using (var db = new DB())
            {
                var model = db.Items.OrderBy(i => i.Price)
                    .Select(i => new ItemModel()
                    {
                        Id = i.Id,
                        Description = i.Description,
                        Location = i.Location,
                        Name = i.Name,
                        Price = i.Price,
                        Category = new CategoryModel()
                        {
                            Id = i.CategoryId,
                        }
                    })
                    .ToList();

                if (id.HasValue)
                {
                    model = model.Where(i => i.Category.Id == id).ToList();
                }

                return View(model);
            }
        }

        // id -> preces ID
        public IActionResult View(int id)
        {
            using(var db = new DB())
            {
                var item = db.Items.Find(id);
                var model = new ItemModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    Location = item.Location,
                    Name = item.Name,
                    Price = item.Price,
                    Category = new CategoryModel()
                    {
                        Id = item.CategoryId,
                    }
                };

                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ItemModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ItemModel model)
        {
            if(ModelState.IsValid)
            {
                using(var db = new DB())
                {
                    var category = db.Categories.FirstOrDefault(c => c.Name == model.CategoryName);

                    if(category != null)
                    {
                        db.Items.Add(new Database.Items()
                        {
                            Price = model.Price,
                            Name = model.Name,
                            Location = model.Location,
                            Description = model.Description,
                            CategoryId = category.Id,
                        });
                        db.SaveChanges();

                        // pārvirza
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("cat", "Category not found!");
                    }
                }
            }

            return View(model);
        }
    }
}