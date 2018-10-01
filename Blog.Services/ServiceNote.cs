using Blog.Contrats;
using System;
using System.Collections.Generic;
using System.Linq;
using static Blog.Contrats.IServiceNote;

namespace Blog.Services
{
    public class ServiceNote : IServicesNotes
    {
        public static List<Note> listNotes = new List<Note>(); 

        public bool Create(Note post)
        {
            var note = new Note { Id = post.Id, Active = true, Date = post.Date, Description = post.Description, IdCategory = post.IdCategory, Title = post.Title };
            listNotes.Add(note); 
           
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Note noteEdit)
        {
            
            if(noteEdit != null)
            {
                foreach (var item in listNotes)
                {
                    if (item.Id == noteEdit.Id)
                    {
                        item.Date = noteEdit.Date;
                        item.Title = noteEdit.Title;
                        item.IdCategory = noteEdit.IdCategory;
                        item.Description = noteEdit.Description;
                        
                    }
                }
            }

            return true;
        }

        public List<Note> GetNotes()
        {
            return listNotes;
        }

        public Note SearchNotes(int id)
        {
            var note = listNotes.Where(x => x.Id == id).FirstOrDefault();

            if (note != null)
            {
                return note;
            }

            return note;
        }
    }
}
