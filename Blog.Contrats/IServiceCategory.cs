using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contrats
{
    public class IServiceCategory
    {
        public interface IServicesCategories
        {
            bool SaveCategory(Category category);
            List<Category> GetCategories();
            
        }
    }
}
