using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWeb.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<EmployeeModel> Employees = new List<EmployeeModel>();

        public IActionResult Index()
        {
            // Jābūt iespējai apskatīt visu darbinieku sarakstu, 
            // kārtotu pēc nodaļas (augoši) un pēc uzvārda (augoši).
            var model = Employees
                .OrderBy(e => e.Department)
                .ThenBy(e => e.Surname)
                .ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if(ModelState.IsValid)
            {
                model.Id = Employees.Count + 1;
                Employees.Add(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // Jābūt iespējai apskatīt sarakstu ar darbinieku nodaļām 
        // (visas unikālās nodaļas no darbinieku saraksta). Mājiens: saraktam jāpielieto .Distinct() metode.
        [HttpGet]
        public IActionResult Departments()
        {
            var model = Employees
                .Select(e => e.Department)
                .Distinct()
                .ToList();

            return View(model);
        }
    }
}