
namespace JeffSingleton.Models
{
    public class GalleryImage
    {
        public int Id { get; set; }

        public int GallerySectionId { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }

        public virtual GallerySection GallerySection { get; set; }
    }
}