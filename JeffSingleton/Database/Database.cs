using System.Data.Entity;
using JeffSingleton.Models;

namespace JeffSingleton.Database
{
    public class Database : DbContext
    {
        public DbSet<GallerySection> GallerySections { get; set; }

        public DbSet<GalleryImage> GalleryImage { get; set; }

        public Database()
        {
            //System.Data.Entity.Database.SetInitializer<EkmDomainsDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GallerySection>()
                .HasMany(s => s.GalleryImages)
                .WithRequired(i => i.GallerySection)
                .HasForeignKey(i => i.GallerySectionId);
        }
    }
}