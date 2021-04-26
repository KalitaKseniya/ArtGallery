using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models.Configuration
{
    public class PaintingConfiguration: IEntityTypeConfiguration<Painting>
    {
        public void Configure(EntityTypeBuilder<Painting> builder)
        {
            builder.HasData(
                new Painting
                {
                    Id = 1,
                    Name = "Звездная ночь",
                    Year = 1889,
                    Medium = "Холст, масло",
                    Size_x = 73.7,
                    Size_y = 92.1,
                    PainterId = 1,
                    //artMovements = 1, 2,
                },
                  new Painting
                  {
                      Id = 2,
                      Name = "Цветущие ветки миндаля",
                      Year = 1890,
                      Medium = "Холст, масло",
                      Size_x = 73.5,
                      Size_y = 92,
                      PainterId = 1,
                     // artMovements = 1, 2
                  },
                     new Painting
                     {
                         Id = 3,
                         Name = "Девятый вал",
                         Year = 1850,
                         Medium = "Холст, масло",
                         Size_x = 221,
                         Size_y = 332,
                         PainterId = 3,
                         // artMovements = 3
                     },
                     new Painting
                     {
                         Id = 4,
                         Name = "Поцелуй",
                         Year = 1908,
                         Medium = "Холст, масло",
                         Size_x = 180,
                         Size_y = 180,
                         PainterId = 2,
                         // artMovements = 2,4,5
                     }
                ) ;
        }
    }
}
