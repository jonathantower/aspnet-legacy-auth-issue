using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthSample.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Login(string username, string password)
		{
			FormsAuthentication.SetAuthCookie(username, false);
			return RedirectToAction("index", "home");
		}
	}
}