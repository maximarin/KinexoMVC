using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class NewsController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        } 

        public ActionResult Create()
        {
            return View();
        } 

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsModel model)
        {   
            return RedirectToAction("Index");
        } 

        [HttpPost]
        public ActionResult Edit (int id)
        {
            return RedirectToAction("Index");
        }
    }
}