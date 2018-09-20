using Blog.Contrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blog.Contrats.IServiceCategory;

namespace Blog.Services
{
    public class ServiceCategory : IServicesCategories
    {
        public static List<Category> list = new List<Category>();


        public List<Category> GetCategories()
        {

            var ejemplo1 = new Category { Name = "Futbol", Active = true, Description = "Primera División Argentina", Id = 1 };
            var ejemplo2 = new Category { Name = "Tenis", Active = true, Description = "Tenis Argentino", Id = 2 };
            list.Add(ejemplo1); list.Add(ejemplo2);

            return list; 

        }

        public bool SaveCategory(Category category)
        {
            category.Id = list.Count + 1;
            list.Add(category);
            return true;
        }
    }
}
