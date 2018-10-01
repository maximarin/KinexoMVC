using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class NoteModel
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(700)]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Categoría")]
        [Required]
        public int IdCategory { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Date { get; set; } 

        public bool Active { get; set; }

        //agregar referencia al usuario que la crea.
    }
}