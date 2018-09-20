using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class CategoryController : Controller
    {
        private static IList<Category> categories = new List<Category>();

        public ActionResult Index()
        {
            var ejemplo1 = new Category { Name = "Futbol", Active = true, Description = "Primera División Argentina", Id = 1 };
            var ejemplo2 = new Category { Name = "Tenis", Active = true, Description = "Tenis Argentino", Id = 2 };

            categories.Add(ejemplo1);
            categories.Add(ejemplo2);
            return View(categories);
        }  

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = categories.Count + 1;
            model.Active = true;

            categories.Add(model);
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            var category = categories.Where(x => x.Id == id).First();

            return View(category); 
        }

        [HttpPost]
        public ActionResult Edit (Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = categories.Where(x => x.Id == model.Id).First();

            category.Name = model.Name;
            category.Description = model.Description;
            category.Active = model.Active;

          
            return RedirectToAction("Index");
        }
    }
}