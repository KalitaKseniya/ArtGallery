using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class ArtMovement
    {
        public int Id { get; set; }
        [Required(ErrorMessage="The name of the art movement is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters")]
        public string Name { get; set; }

        public List<Painting> Paintings{get;set;}
    }
}
