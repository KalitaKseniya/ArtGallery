using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ArtGallery.Models.Configuration;

namespace ArtGallery.Models
{
    public class RepositoryContext: DbContext
    {
        public DbSet<Painter> Painters { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<ArtMovement> ArtMovements { get; set; }
        public RepositoryContext(DbContextOptions options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaintingConfiguration());
            modelBuilder.ApplyConfiguration(new PainterConfiguration());
            modelBuilder.ApplyConfiguration(new ArtMovementConfiguration());
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS2019;Database=GalleryCore;Trusted_Connection=True;");
        //}
    }
}
