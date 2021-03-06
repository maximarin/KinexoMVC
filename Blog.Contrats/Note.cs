﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contrats
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int IdCategory { get; set; }

        public DateTime Date { get; set; }

        public bool Active { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
