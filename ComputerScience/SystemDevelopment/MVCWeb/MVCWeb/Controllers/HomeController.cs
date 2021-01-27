using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Models.Home.Index i = new Models.Home.Index();

            
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.Home.Index i)
        {
            if (i.eMail.Equals("fer@mail.com") && i.password.Equals("12345"))
            {
                //return RedirectToAction("loggedin");
            }
            return View(i);
        }
    }
}