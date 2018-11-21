using Blog.Contrats;
using Blog.Models;
using Blog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Blog.Contrats.IServiceCategory;
using static Blog.Contrats.IServiceNote;

namespace Blog.Controllers
{
    [Authorize (Users= "marinmaximiliano99@gmail.com")]      //Solo el usuario admin puede accerder a todoas las funciones. 
    public class NoteController : Controller
    {
        private readonly IServicesNotes NoteService;
        private readonly IServicesCategories CategoryService;

        
        public NoteController(IServicesNotes NoteService, IServicesCategories CategoryService)
        {
            this.NoteService = NoteService;
            this.CategoryService = CategoryService;
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

       
    }
}