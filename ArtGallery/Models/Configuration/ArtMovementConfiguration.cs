using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models.Configuration
{
    public class ArtMovementConfiguration : IEntityTypeConfiguration<ArtMovement>
    {
        public void Configure(EntityTypeBuilder<ArtMovement> builder)
        {
            builder.HasData(
                new ArtMovement
                {
                    Id = 1,
                    Name = "Постимпрессионизм"
                },
                new ArtMovement
                {
                    Id = 2,
                    Name = "Модернизм в изобразительном искусстве"
                },
                new ArtMovement
                {
                    Id = 3,
                    Name = "Романтизм"
                },
                   new ArtMovement
                   {
                       Id = 4,
                       Name = "Модерн"
                   }, new ArtMovement
                   {
                       Id = 5,
                       Name = "Символизм"
                   }

                );
        }
    }
}
