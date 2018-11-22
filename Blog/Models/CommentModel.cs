using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string IdUser { get; set; }

        public int IdNote { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}