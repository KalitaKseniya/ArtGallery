using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Login is a required field")]
        [MaxLength(20, ErrorMessage = "Maximum length for Login is 20 characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is a required field")]
        [MaxLength(50, ErrorMessage = "Maximum length for Password is 50 characters")]
        public string Password { get; set; }
    }
}
