using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models.Configuration
{
    public class PainterConfiguration: IEntityTypeConfiguration<Painter>
    {
        public void Configure(EntityTypeBuilder<Painter> builder)
        {
            builder.HasData(
                new Painter
                {
                    Id = 1,
                    FirstName = "Винсент",
                    LastName = "Ван Гог",
                    Age = 37,
                    BirthDate = new DateTime(1853, 03, 30),
                    DeathDate = new DateTime(1853, 03, 30),
                    BirthPlace = "Грот-Зюндерт",
                    DeathPlace = "Овер-сюр-Уаз",
                    Country = "Нидерланды"
                },
                new Painter
                {
                    Id = 2,
                    FirstName = "Густав",
                    LastName = "Климт",
                    Age = 55,
                    BirthDate = new DateTime(1862, 07, 14),
                    DeathDate = new DateTime(1918, 02, 6),
                    BirthPlace = "Вена",
                    DeathPlace = "Вена",
                    Country = "Австрийская империя"
                },
                 new Painter
                 {
                     Id = 3,
                     FirstName = "Иван",
                     LastName = "Айвазовский",
                     FathersName = "Константинович",
                     Age = 82,
                     BirthDate = new DateTime(1817, 07, 17),
                     DeathDate = new DateTime(1900, 04, 19),
                     BirthPlace = "Феодосия, Таврическая губерния, Российская империя",
                     DeathPlace = "	Феодосия, Таврическая губерния, Российская империя",
                     Country = "Российская империя"
                 }

                );

        }
    }
}
