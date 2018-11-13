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
    [Authorize (Users= "marinmaximiliano99@gmail.com")]
    public class CategoryController : Controller
    {
    
        private readonly IServicesCategories categoryService;
        public CategoryController(IServicesCategories categoryService)
        {
            this.categoryService = categoryService; 
        }

        [AllowAnonymous]
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

       
        public ActionResult Delete(int id)
        {   
            if (categoryService.EditCategory(categoryService.SearchCategory(id), true))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = new Category { Id = model.Id, Active = model.Active, Description = model.Description, Name = model.Name };
            categoryService.SaveCategory(category);

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            var category = categoryService.SearchCategory(id); 

            return View(new CategoryModel {Id = category.Id, Name = category.Name, Active = category.Active, Description = category.Description}); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = new Category { Id = model.Id, Active = model.Active, Description = model.Description, Name = model.Name };

            categoryService.EditCategory(category,false);

            return RedirectToAction("Index");
        }

    }
}