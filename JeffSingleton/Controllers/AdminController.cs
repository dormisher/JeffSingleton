using System.Web.Mvc;
using JeffSingleton.Models.ViewModels;
using JeffSingleton.Database;
using System.Linq;
using System.Web;
using JeffSingleton.Models;
using System.IO;
using System.Drawing;
using System;

namespace JeffSingleton.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        JsDatabase _db = new JsDatabase();

        public ActionResult Index()
        {
            return RedirectToAction("Images", new { section = (int)GallerySectionsType.Paintings });
        }

        public ActionResult Images(int section)
        {
            var model = new AdminViewModel
            {
                GallerySection = section
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Images(AdminViewModel model)
        {
            if (!ValidateNewImage(model))
            {
                return View(model);
            }

            SaveImage(model);

            return RedirectToAction("Images", new { section = model.GallerySection });
        }

        public ActionResult GetImageList(int section)
        {
            var images = _db.GalleryImages.Where(i => i.GallerySection == (int)section)
                .OrderBy(i => i.Order)
                .ToList();

            return PartialView("ImageList", images);
        }

        public ActionResult UpdateOrder(int id, bool up)
        {
            var image = _db.GalleryImages.Find(id);
            var images = _db.GalleryImages.Where(i => i.GallerySection == image.GallerySection);

            int oldOrder = image.Order;
            int newOrder = up ? image.Order - 1 : image.Order + 1;

            if (newOrder != 0 && newOrder <= _db.GalleryImages.Count())
            {
                image.Order = newOrder;
            }

            var sibling = images.SingleOrDefault(i => i.GallerySection == image.GallerySection && i.Order == newOrder);
            if (sibling != null)
            {
                sibling.Order = oldOrder;
            }

            _db.SaveChanges();

            return RedirectToAction("Images", new { section = image.GallerySection });
        }

        public ActionResult DeleteImage(int id)
        {
            var image = _db.GalleryImages.Single(i => i.Id == id);

            _db.GalleryImages.Remove(image);
            _db.SaveChanges();

            System.IO.File.Delete(HttpContext.Server.MapPath(image.Filename));

            return RedirectToAction("Images", new { section = image.GallerySection });
        }

        #region private

        private void SaveImage(AdminViewModel model)
        {
            string fileName = Request.Files[0].FileName;
            var type = (GallerySectionsType)model.GallerySection;

            string path = "";
            if (type == GallerySectionsType.Paintings)
            {
                path = "~/Content/GalleryImages/Paintings/";
            }
            else if (type == GallerySectionsType.Photography)
            {
                path = "~/Content/GalleryImages/Photography/";
            }
            else if (type == GallerySectionsType.Sculptures)
            {
                path = "~/Content/GalleryImages/Sculptures/";
            }
            else if (type == GallerySectionsType.Installations)
            {
                path = "~/Content/GalleryImages/Installations/";
            }

            // save main file
            Request.Files[0].SaveAs(HttpContext.Server.MapPath(path) + fileName);

            // save thumnail
            var mainImage = Image.FromFile(Server.MapPath(path + fileName));

            double fraction = 50.0 / (double)mainImage.Width;
            int height = (int)(mainImage.Height * fraction);

            Image thumb = mainImage.GetThumbnailImage(50, height, new Image.GetThumbnailImageAbort(() => true), IntPtr.Zero);

            string thumbPath = path + "/Thumbs/" + fileName;
            thumb.Save(Server.MapPath(thumbPath));

            // add to db
            _db.GalleryImages.Add(new GalleryImage
            {
                Filename = path + fileName,
                Thumbnail = path + "/Thumbs/" + fileName,
                GallerySection = (int)model.GallerySection,
                Width = mainImage.Width,
                Height = mainImage.Height,
                Info = model.Info,
                Title = model.Title,
                Order = _db.GalleryImages.Where(i => i.GallerySection == model.GallerySection).Count() + 1
            });
            _db.SaveChanges();
        }

        private bool ValidateNewImage(AdminViewModel model)
        {
            bool valid = true;
            if (Request.Files.Count == 0)
            {
                ModelState.AddModelError("", "Select a file");
                valid = false;
            }

            if (string.IsNullOrEmpty(model.Info))
            {
                ModelState.AddModelError("", "Enter info");
                valid = false;
            }

            if (string.IsNullOrEmpty(model.Title))
            {
                ModelState.AddModelError("", "Enter a title");
                valid = false;
            }

            if (_db.GalleryImages.SingleOrDefault(i => i.Title == model.Title) != null)
            {
                ModelState.AddModelError("", "Image with this title exists");
            }

            return valid;
        }

        #endregion
    }
}
