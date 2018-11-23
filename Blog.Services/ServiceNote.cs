using Blog.Contrats;
using Blog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using static Blog.Contrats.IServiceNote;

namespace Blog.Services
{
    public class ServiceNote : IServicesNotes
    {
        public bool Create(Note post)
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();

            contex.Notes.Add(new Notes
            {
                Title = post.Title,
                IdCategory = post.IdCategory,
                Active = true,
                Description = post.Description,
                Date = post.Date

            });
            contex.SaveChanges();
            return true;
        }

        public bool Edit(Note noteEdit, bool delete)
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();

            Notes note = contex.Notes.Where(x => x.Id == noteEdit.Id && x.Active == true).FirstOrDefault();

            if (delete == true && note != null)
            {
                note.Active = false;

                contex.SaveChanges();

                return true;
            }
            else
            {

                if (note != null)
                {
                    note.Date = noteEdit.Date;
                    note.Title = noteEdit.Title;
                    note.IdCategory = noteEdit.IdCategory;
                    note.Description = noteEdit.Description;
                    note.Date = noteEdit.Date;
                    contex.SaveChanges();

                    return true;
                }

                return false;
            }

        }


        public List<Note> GetNotes()
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();
            List<Note> notes = new List<Note>();


            var listnotes = contex.Notes.Where(x => x.Active == true).ToList();

            foreach (var item in listnotes)
            {
                notes.Add(new Note()
                {
                    Title = item.Title,
                    Id = item.Id,
                    Description = item.Description,
                    Date = item.Date,
                    Active = item.Active,
                    IdCategory = item.IdCategory

                });
            }

            return notes;
        }

        public Note SearchNotes(int id)
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();

            var noteSearch = contex.Notes.Where(x => x.Id == id && x.Active == true).FirstOrDefault();
            var comments = new List<Commentss>();
            comments = contex.Commentss.Where(x => x.IdNote == id).ToList();
            var listComments = new List<Comment>();

            foreach (var item in comments)
            {
                var comment = new Comment();
                comment.Active = item.Active;
                comment.Description = item.Description;
                comment.Id = item.Id;
                comment.IdNote = item.IdNote;
                comment.IdUser = item.IdUser;

                listComments.Add(comment);
            }

            Note note = (noteSearch == null) ? null : new Note()
            {
                Title = noteSearch.Title,
                Id = noteSearch.Id,
                IdCategory = noteSearch.IdCategory,
                Active = noteSearch.Active,
                Date = noteSearch.Date,
                Description = noteSearch.Description,
                Comments = listComments

            };

            return note;
        }

        
    }
}

