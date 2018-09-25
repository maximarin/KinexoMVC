using Blog.Contrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blog.Contrats.IServiceNews;

namespace Blog.Services
{
    public class ServiceNews : IServicesNews
    {
        public bool Create(News post)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(int id)
        {
            throw new NotImplementedException();
        }

        public List<News> GetNews()
        {
            throw new NotImplementedException();
        }

        public News SearchNews(int id)
        {
            throw new NotImplementedException();
        }
    }
}
