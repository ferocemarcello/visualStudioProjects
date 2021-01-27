using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPractiseMVC.Controllers
{
    public class BlogPostsController : Controller
    {
        static LinkedList<Models.BlogPost> bps = new LinkedList<Models.BlogPost>();
        static BlogPostsController()
        {
            Models.BlogPost bp = new Models.BlogPost(0, "first post", "this is a post, it is very long ahaha", DateTime.Now, "Marcello Feroce");
            Models.BlogPost bp2 = new Models.BlogPost(1, "second post", "this is a post, it is very short ahaha", DateTime.Now, "Steve Jobs");
            bps.AddLast(bp);
            bps.AddLast(bp2);
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index",bps);
        }
        [HttpPost]
        public ActionResult LookForAuthor(string submit,string autname)
        {
            ViewBag.Author = autname;
            TempData["Author"] = autname;
            return View("IndexAuthor", bps);
        }
        [HttpPost]
        public ActionResult WriteNewPost(string submit, string content,string title,int idnumber)
        {
            if (TempData["Author"] == null)
            {
                return View("Index", bps);
            }
            string autname = (string)TempData["Author"];
            TempData["Author"] = autname;
            
            Models.BlogPost bp = new Models.BlogPost(idnumber, content, title, DateTime.Now, autname);
            bps.AddLast(bp);
            ViewBag.Author = autname;
            return View("IndexAuthor",bps);
            //return View("Index", bps);

        }
    }
}
