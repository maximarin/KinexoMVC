using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Blog.Contrats.IServiceCategory;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicesCategories categoryService;

        public HomeController(IServicesCategories CategoryService)
        {
            this.categoryService = CategoryService;

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}