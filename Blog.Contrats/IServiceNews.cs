using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contrats
{
  public class IServiceNews
    { 
      public  interface IServicesNews
        {
            bool Create(News post);
            bool Edit(int id);
            bool Delete(int id);
            List<News> GetNews();
            News SearchNews(int id);
        }
    }
}
