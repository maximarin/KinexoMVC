using Blog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blog.Contrats.IServiceUser;
using Blog.Contrats;

namespace Blog.Services
{
   public class ServiceUser : IServicesUsers
    {
        public User GetUser(string id)
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();

            AspNetUsers userSearch = contex.AspNetUsers.Where(x => x.Id == id).FirstOrDefault();

            var user = new User();

            if(userSearch != null)
            {
                user.Id = userSearch.Id;
                user.Name = userSearch.Name;
                user.SurName = userSearch.SurName;
                user.Email = userSearch.SurName;
            }

            return user;
        }
    }
}
