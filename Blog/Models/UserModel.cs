using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [Required]
        [MaxLength(50)]
        public string SurName { get; set; }

        [Display(Name = "Dirección de email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

    }
}