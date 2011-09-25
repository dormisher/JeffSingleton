using System.Web.Mvc;
using System.Drawing;
using JeffSingleton.Database;
using System.Linq;
using System;
using JeffSingleton.Models.ViewModels;

namespace JeffSingleton.Controllers
{
    public class GalleryController : Controller
    {
        JsDatabase _db = new JsDatabase();

        public ActionResult Index(int section, int order)
        {
            var model = new GalleryViewModel();

            model.Main = _db.GalleryImages.SingleOrDefault(i => i.GallerySection == section && i.Order == order);
            model.CurrentOrder = order;
            model.GallerySection = section;
            model.Images = _db.GalleryImages.Where(i => i.GallerySection == section).OrderBy(i => i.Order).ToList();

            return View(model);
        }        
    }
}
