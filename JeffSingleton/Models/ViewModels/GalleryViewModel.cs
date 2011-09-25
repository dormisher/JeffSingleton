using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JeffSingleton.Models.ViewModels
{
    public class GalleryViewModel
    {
        public GalleryImage Main { get; set; }

        public int CurrentOrder { get; set; }

        public int GallerySection { get; set; }

        public List<GalleryImage> Images { get; set; }
    }
}