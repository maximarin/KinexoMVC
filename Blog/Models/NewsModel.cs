using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class NewsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int IdCategory { get; set; }

        public DateTime Date { get; set; } 

        public bool Active { get; set; }

        //agregar referencia al usuario que la crea.
    }
}