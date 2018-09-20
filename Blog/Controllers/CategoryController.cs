using Blog.Contrats;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Blog.Contrats.IServiceCategory;

namespace Blog.Controllers
{
    public class CategoryController : Controller
    {
    

        private readonly IServicesCategories categoryService;
        public CategoryController(IServicesCategories categoryService)
        {
            this.categoryService = categoryService; 
        }

        public ActionResult Index()
        {
            var categories = categoryService.GetCategories();

            IList<CategoryModel> categories1 = new List<CategoryModel>();

            foreach (var cat in categories)
            {
                var creada = new CategoryModel { Id = cat.Id, Active = cat.Active, Description = cat.Description, Name = cat.Name };
                categories1.Add(creada);
            }


            return View(categories1);
        }  

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var category = new Category { Id = model.Id, Active = model.Active, Description = model.Description, Name = model.Name };
            categoryService.SaveCategory(category);

            return RedirectToAction("Index");

        }

        //public ActionResult Edit(int id)
        //{
        //    var category = categories.Where(x => x.Id == id).First();

        //    return View(category); 
        //}

        //[HttpPost]
        //public ActionResult Edit (CategoryModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var category = categories.Where(x => x.Id == model.Id).First();

        //    category.Name = model.Name;
        //    category.Description = model.Description;
        //    category.Active = model.Active;


        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public ActionResult Delete (int id)
        //{
        //    var category = categories.Where(x => x.Id == id).Single();
        //    categories.Remove(category); 
        //    return RedirectToAction("Index");
        //}
    }
}