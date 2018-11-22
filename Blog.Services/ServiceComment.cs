using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Contrats;
using static Blog.Contrats.IServiceComment;
using Blog.DataAccess;

namespace Blog.Services
{
    public class ServiceComment : IServicesComments
    {
        public bool AddComment(Comment comment)
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();

            contex.Commentss.Add(new Commentss
            {
                IdNote = comment.IdNote,
                IdUser = comment.IdUser,
                Active = true,
                Description = comment.Description

            }
                );

            contex.SaveChanges();

            return true;
        }
    }
}
