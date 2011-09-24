using System.Web.Mvc;
using System.Drawing;
using JeffSingleton.Database;
using System.Linq;
using System;

namespace JeffSingleton.Controllers
{
    public class GalleryController : Controller
    {
        JsDatabase _db = new JsDatabase();

        public ActionResult Index(int section)
        {
            return View();
        }        
    }
}
