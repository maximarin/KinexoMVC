using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contrats
{
    public class IServiceComment
    {
        public interface IServicesComments
        {
            bool AddComment(Comment comment);
            List<Comment> GetComments();
            bool Edit(Comment comment, bool delete);
            Comment SearchComment(int id);
        }
            
    }
}
