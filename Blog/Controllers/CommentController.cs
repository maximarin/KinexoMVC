using Blog.Contrats;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Blog.Contrats.IServiceComment;

namespace Blog.Controllers
{
    [Authorize(Roles ="Administrador")]
    public class CommentController : Controller
    {
        private readonly IServicesComments CommentService;

        public CommentController(IServicesComments CommentService)
        {
            this.CommentService = CommentService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var comments = CommentService.GetComments();

            IList<CommentModel> commentsModel = new List<CommentModel>();

            foreach (var item in comments)
            {
                var comment = new CommentModel()
                {
                    Description = item.Description,
                    Id = item.Id,
                    IdUser = item.IdUser,
                    IdNote = item.IdNote,
                    Active = item.Active
                };

                commentsModel.Add(comment);
            }


            return View(commentsModel);
        }


        public ActionResult Delete(int id)
        {
            if(CommentService.SearchComment(id) != null)
            {
                CommentService.Edit(CommentService.SearchComment(id), true);
            }

            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult Edit (int id)
        {
            Comment commentSearch = CommentService.SearchComment(id);
            var commentModel = new CommentModel()
            {
                Description = commentSearch.Description,
                Id = commentSearch.Id,
                IdUser = commentSearch.IdUser,
                IdNote = commentSearch.IdNote,
                Active = commentSearch.Active
            };

            return View(commentModel);
        }

        [HttpPost]
        public ActionResult Edit(CommentModel model)
        {
            var comment = new Comment()
            {
                Active = true,
                IdNote = model.IdNote,
                IdUser = model.IdUser,
                Description = model.Description
            };

            if (CommentService.Edit(comment, false))
            {
               return  RedirectToAction("Index");
            }

            return RedirectToAction("Edit", new { id = model.Id });

        }
    }
}