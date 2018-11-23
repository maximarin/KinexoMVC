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

        public List<Comment> GetComments()
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();
            var comments = new List<Comment>();
           
            foreach (var item in contex.Commentss.Where(x => x.Active == true).ToList())
            {
                var comment = new Comment()
                {
                    Id = item.Id,
                    Description = item.Description,
                    IdNote = item.IdNote,
                    IdUser = item.IdUser,
                    Active = item.Active
                };

                comments.Add(comment);
            }

            return comments;
        }

        public bool Edit(Comment commentEdit, bool delete)
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();

            Commentss comment = contex.Commentss.Where(x => x.Id == commentEdit.Id && x.Active == true).FirstOrDefault();

            if (delete == true && comment != null)
            {
                comment.Active = false;

                contex.SaveChanges();

                return true;
            }
            else
            {

                if (comment != null)
                {
                    comment.Description = commentEdit.Description;

                    contex.SaveChanges();

                    return true;
                }

                return false;
            }

        }

        public Comment SearchComment(int id)
        {
            BlogKinexoEntities contex = new BlogKinexoEntities();

            Commentss commentSearch = contex.Commentss.Where(x => x.Id == id && x.Active == true).FirstOrDefault();

            Comment comment = (commentSearch == null) ? null : new Comment()
            {
                Active = commentSearch.Active,
                Description = commentSearch.Description,
                Id = commentSearch.Id,
                IdNote = commentSearch.IdNote,
                IdUser = commentSearch.IdUser
            };

            return comment;

        }
    }
}
