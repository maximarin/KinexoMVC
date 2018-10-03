using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contrats
{
  public class IServiceNote
    { 
      public  interface IServicesNotes
        {
            bool Create(Note post);
            bool Edit(Note note, bool delete);
            List<Note> GetNotes();
            Note SearchNotes(int id);
        }
    }
}
