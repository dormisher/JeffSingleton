using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JeffSingleton.Models
{
    public class GallerySection
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<GalleryImage> GalleryImages { get; set; }
    }
}