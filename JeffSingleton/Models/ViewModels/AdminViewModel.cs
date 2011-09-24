using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JeffSingleton.Models.ViewModels
{
    public class AdminViewModel
    {
        public int GallerySection { get; set; }

        public string Info { get; set; }

        public string Title { get; set; }

        public HttpPostedFile Image { get; set; }

        public List<SelectListItem> GetSelectList()
        {
            var items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = GallerySectionsType.Paintings.ToString(), Value = ((int)GallerySectionsType.Paintings).ToString() });
            items.Add(new SelectListItem { Text = GallerySectionsType.Photography.ToString(), Value = ((int)GallerySectionsType.Photography).ToString() });            
            items.Add(new SelectListItem { Text = GallerySectionsType.Sculptures.ToString(), Value = ((int)GallerySectionsType.Sculptures).ToString() });
            items.Add(new SelectListItem { Text = GallerySectionsType.Installations.ToString(), Value = ((int)GallerySectionsType.Installations).ToString() });

            return items;
        }
    }
}