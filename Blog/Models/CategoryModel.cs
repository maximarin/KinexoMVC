using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class CategoryModel
    { 
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre de la Categoria")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [MaxLength(256)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Activa")]
        public bool Active { get; set; } 


    }
}