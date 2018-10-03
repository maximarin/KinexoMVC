using Blog.Contrats;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Blog.Contrats.IServiceNote;

namespace Blog.Controllers
{
    public class NoteController : Controller
    {
        private readonly IServicesNotes NoteService;
        public NoteController(IServicesNotes NoteService)
        {
            this.NoteService = NoteService;
        }

        public ActionResult Index()
        {
            var notes = NoteService.GetNotes();

            IList<NoteModel> notes1 = new List<NoteModel>();

            foreach (var not in notes)
            {
                var creada = new NoteModel { Id = not.Id, Active = true , Description = not.Description, Title = not.Title, Date = DateTime.Now , IdCategory = not.IdCategory };
                notes1.Add(creada);
            }

            return View(notes1);
        } 

        [ValidateInput(false)]
        public ActionResult Create()
        {
            return View();
        } 

        public ActionResult Edit(int id)
        {
            var note = NoteService.SearchNotes(id);

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
        public ActionResult Edit (NoteModel model)
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


            if (NoteService.Edit(note,false))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}