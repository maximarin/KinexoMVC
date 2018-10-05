using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            return View();
        }

        
    }
}