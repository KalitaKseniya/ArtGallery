using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ArtGallery.Models
{
    //todo add and check reauired
    public class Painter
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter last name")]
        [MaxLength(100, ErrorMessage ="Maximum length of last name is 100")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        [MaxLength(50, ErrorMessage = "Maximum length of first name is 50")]
        public string FirstName { get; set; }
        [MaxLength(60, ErrorMessage = "Maximum length of father's name is 60")]
        public string FathersName { get; set; }
        public DateTime? BirthDate { get; set; } 
        [MaxLength(100, ErrorMessage ="Maximum length of birth place is 100")]
        public string BirthPlace { get; set; }//nullable??
        public DateTime? DeathDate { get; set; }
        [MaxLength(100, ErrorMessage = "Maximum length of death place is 100")]
        public string DeathPlace { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Must be non-negative")]
        public int? Age { get; set; }
        [Required(ErrorMessage ="Please enter country")]
        [MaxLength(100, ErrorMessage = "Maximum length of Country is 100")]
        public string Country { get; set; }
        public virtual List<Painting> Paintings { get; set; }
    }
}
