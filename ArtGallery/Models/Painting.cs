using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class Painting
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage ="Maximum length of last name is 300")]
        [Required(ErrorMessage = "Поле \"Название\" является обязательным для ввода")]
        public string Name { get; set; }
        public int Year { get; set; }
        [MaxLength(100,ErrorMessage ="Максимальная длина для поля \"Материал\" - 100 символов")]
        public string Medium { get; set; }
        public double? Size_x { get; set; }
        public double? Size_y { get; set; }
        public string Description { get; set; }
        public int PainterId { get; set; }
        //Required??
        //ToDo путь к картинке добавить
         public Painter Painter { get; set; }
         public List<ArtMovement> artMovements { get; set; }
    }
}
