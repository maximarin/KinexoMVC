using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contrats
{
  public class IServiceNews
    { 
      public  interface IServicesNotes
        {
            bool Create(Note post);
            bool Edit(int id);
            bool Delete(int id);
            List<Note> GetNews();
            Note SearchNews(int id);
        }
    }
}
