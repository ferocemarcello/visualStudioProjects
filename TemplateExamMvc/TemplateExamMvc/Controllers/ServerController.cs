using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateExamMvc.Models;

namespace TemplateExamMvc.Controllers
{
    public class ServerController : Controller
    {
        private static List<Item> items;
        private Object lockOnItems = new Object();
        // GET: Server
        [HttpGet]
        public ActionResult Index()
        {
            return View(items);
        }

        static ServerController()
        {
            InitFields();
        }
        [HttpPost]
        public ActionResult LookForItem(string submit, int itemnumber)
        {
            /*var httpContext = Request.Properties["MS_HttpContext"] as System.Web.HttpContextWrapper;//to use session
            httpContext.Application.Lock();
            lock and unlock to lock and unlock
            httpContext.Session["Operations"] == null
            httpContext.Application.UnLock();*/

            //TempData["Author"] = autname;
            ViewBag.itemnumber = itemnumber;
            return View("IndexItem", items.Where(i => i.ItemNumber==itemnumber));
        }
        private static void InitFields()
        {
            items = new List<Item>();items.Add(new Item(0)); items.Add(new Item(1)); items.Add(new Item(2)); items.Add(new Item(3));
        }
    }
}