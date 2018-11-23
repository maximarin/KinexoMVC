using Blog.Contrats;
using Blog.Models;
using Blog.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Blog.Contrats.IServiceCategory;
using static Blog.Contrats.IServiceComment;
using static Blog.Contrats.IServiceNote;

namespace Blog.Controllers
{
    [Authorize (Users= "marinmaximiliano99@gmail.com")]      //Solo el usuario admin puede accerder a todoas las funciones. 
    public class NoteController : Controller
    {
        private readonly IServicesNotes NoteService;
        private readonly IServicesCategories CategoryService;
        private readonly IServicesComments CommentService;


        public NoteController(IServicesNotes NoteService, IServicesCategories CategoryService, IServicesComments CommentService)
        {
            this.NoteService = NoteService;
            this.CategoryService = CategoryService;
            this.CommentService = CommentService;
        }

        [AllowAnonymous]  // el index puede ser accedido por todos los usuarios 
        public ActionResult Index()
        {
            var notes = NoteService.GetNotes();

            IList<NoteModel> notes1 = new List<NoteModel>();

            foreach (var not in notes)
            {
                var creada = new NoteModel { Id = not.Id, Active = true , Description = not.Description.ToString(), Title = not.Title, Date = Convert.ToDateTime(not.Date.ToString()), IdCategory = not.IdCategory };
                notes1.Add(creada);
            }

            return View(notes1);
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var note = NoteService.SearchNotes(id);

            var listComments = new List<CommentModel>();
            foreach (var item in note.Comments)
            {
                var comment = new CommentModel();
                comment.Active = item.Active;
                comment.Description = item.Description;
                comment.Id = item.Id;
                comment.IdNote = item.IdNote;
                comment.IdUser = item.IdUser;

                listComments.Add(comment);
            }


            return View(new NoteModel { Id = note.Id, Date = note.Date, Title = note.Title, Active = note.Active, Description = note.Description, IdCategory = note.IdCategory, Commments = listComments});
        }
      
        public ActionResult IndexAdmin()
        {
            var notes = NoteService.GetNotes();

            IList<NoteModel> notes1 = new List<NoteModel>();

            foreach (var not in notes)
            {
                var creada = new NoteModel { Id = not.Id, Active = true, Description = not.Description, Title = not.Title, Date = not.Date.Date, IdCategory = not.IdCategory };
                notes1.Add(creada);
            }

            return View(notes1);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(CategoryService.GetCategories().ToList(),
                                               nameof(Category.Id), nameof(Category.Name));
            return View();
        } 

        public ActionResult Edit(int id)
        {
            var note = NoteService.SearchNotes(id);

            ViewBag.Categories = new SelectList(CategoryService.GetCategories().ToList(),
                                              nameof(Category.Id), nameof(Category.Name));

            return View(new NoteModel { Id= note.Id, Date = note.Date, Title = note.Title, Active = note.Active, Description= note.Description, IdCategory= note.IdCategory });
            
        }

        public ActionResult Delete(int id)
        {
            if (NoteService.Edit(NoteService.SearchNotes(id), true))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NoteModel model)
        {
            var note = new Note()
            {
                Active = true,
                Date = DateTime.Now,
                Title = model.Title,
                Description = model.Description,
                Id = model.Id,
                IdCategory = model.IdCategory

            };

            if (NoteService.Create(note))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        } 

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit (NoteModel model)
        {
            var note = new Note()
            {
                Active = true,
                Date = DateTime.Now,
                Title = model.Title,
                Description = model.Description.ToString(),
                Id = model.Id,
                IdCategory = model.IdCategory
            }; 

            if (NoteService.Edit(note,false))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Comment (int id)
        {
            var model = new CommentModel();
            model.IdNote = id;
            model.Active = true; 

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Comment (CommentModel model)
        {
            var comment = new Comment()
            {
                Active = true,
                IdNote = model.IdNote,
                IdUser = User.Identity.GetUserId(),
                Description = model.Description
            };

            CommentService.AddComment(comment);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Search()
        {
            var notes = NoteService.GetNotes();

            IList<NoteModel> notes1 = new List<NoteModel>();

            foreach (var not in notes)
            {
                var creada = new NoteModel { Id = not.Id, Active = true, Description = not.Description.ToString(), Title = not.Title, Date = Convert.ToDateTime(not.Date.ToString()), IdCategory = not.IdCategory };
                notes1.Add(creada);
            }

            return View(notes1);
        }

    }
}