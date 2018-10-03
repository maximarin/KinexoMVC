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
        public bool EditCategory(Category catEdit, bool delete)
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();

            Categories categoryEdit = contex.Categories.Where(x => x.Id == catEdit.Id).FirstOrDefault();

            if (delete == true && categoryEdit != null )
            {
                categoryEdit.Active = false;
                contex.SaveChanges();

                return true;
            }
            else
            {
                //VALIDO SI EL ID EXISTE
                if (categoryEdit != null)
                {
                    categoryEdit.Description = catEdit.Description;
                    categoryEdit.Name = catEdit.Name;

                    contex.SaveChanges();

                    return true;
                }
                return false;
            }
            
        }

        public List<Category> GetCategories()
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();
            List<Category> Categories = new List<Category>();
            
            //Obtenemos solo las que no se encuentran eliminadas
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

            contex.SaveChanges();

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
