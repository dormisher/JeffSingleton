using System.ComponentModel.DataAnnotations;

namespace JeffSingleton.Models
{
    public class GalleryImage
    {
        [Key]
        public int Id { get; set; }

        public string Filename { get; set; }

        public string Thumbnail { get; set; }

        public int GallerySection { get; set; }

        public int Order { get; set; }

        public string Title { get; set; }

        public string Info { get; set; }
    }
}