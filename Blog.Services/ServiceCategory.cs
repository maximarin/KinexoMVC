using Blog.Contrats;
using Blog.DataAccess;
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

        public bool DeleteCategory(int id)
        {
            var categoryDelete = list.Where(x => x.Id == id).FirstOrDefault(); 
            
            if (categoryDelete != null)
            {
                list.Remove(categoryDelete);
                return true;
            }

            return false;
        }

        public bool EditCategory(Category catEdit)
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();

            var categoryEdit = contex.Categories.Where(x => x.Id == catEdit.Id).FirstOrDefault();

            //VALIDO SI EL ID EXISTE
            if (categoryEdit != null)
            {
                foreach (var item in list)
                {
                    if (item.Id == categoryEdit.Id)
                    {
                        item.Active = catEdit.Active;
                        item.Description = catEdit.Description;
                        item.Name = catEdit.Name;
                        break;
                    }

                }
                
                return true;
            }
            return false;
        }

        public List<Category> GetCategories()
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();
            List<Category> Categories = new List<Category>();

            var CategoriesBD = contex.Categories.Where(x => x.Active == true);

            foreach (var item in CategoriesBD.ToList())
            {
                Categories.Add(new Category
                {
                    Name = item.Name,
                    Id = item.Id,
                    Active = item.Active,
                    Description = item.Description

                });

            }

            return Categories; 

        }

        public bool SaveCategory(Category category)
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();

            contex.Categories.Add(new Categories
            {
                Name = category.Name,
                Description = category.Description,
                Active = true

            });

            return true; 

        }

        public Category SearchCategory(int id)
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();

            var category = contex.Categories.Where(x => x.Id == id && x.Active == true).FirstOrDefault();

            Category cat = (category == null) ? null : new Category()
            {
                Name = category.Name,
                Description = category.Description,
                Id = category.Id

            };

            return cat;
        }
    }
}
