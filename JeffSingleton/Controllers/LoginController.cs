using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JeffSingleton.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (FormsAuthentication.Authenticate(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, true);
            }
            
            ModelState.AddModelError("", "");
            return RedirectToAction("Index", new {Controller = "Admin"});
        }
    }
}
