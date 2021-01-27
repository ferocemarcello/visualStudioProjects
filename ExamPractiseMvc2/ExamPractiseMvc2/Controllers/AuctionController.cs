using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPractiseMvc2.Controllers
{
    public class AuctionController : Controller
    {
        private static AuctionServiceReference1.AuctionsServiceClient cl = new AuctionServiceReference1.AuctionsServiceClient();

        // GET: Auction
        public ActionResult Index()
        {
            return View(cl.GetAllAuctionItems());
        }
        [HttpGet]
        public ActionResult LookForItem(string submit, int itemnumber)
        {
            ViewBag.itemnumber = itemnumber;
            List<AuctionServiceReference1.AuctionItem> l = cl.GetAllAuctionItems().ToList();
            l = l.Where(i => i.ItemNumber == itemnumber).ToList();
            if (l.Count <= 0) return View("BadIndex", cl.GetAllAuctionItems());
            //var httpContext = Request.Properties["MS_HttpContext"] as System.Web.HttpContextWrapper;
            HttpContext.Session["ItemNumber"] = itemnumber;
            return View("IndexItem", l);
        }
        [HttpGet]
        public ActionResult Bid(string submit, int bidprice, string customname, string customphone)
        {
            //var httpContext = Request.Properties["MS_HttpContext"] as System.Web.HttpContextWrapper;
            cl.ProvideBid((int)HttpContext.Session["ItemNumber"], bidprice, customname, customphone);
            List<AuctionServiceReference1.AuctionItem> l = cl.GetAllAuctionItems().ToList();
            l = l.Where(i => i.ItemNumber == (int)HttpContext.Session["ItemNumber"]).ToList();
            return View("IndexItem", l);
        }
        static AuctionController()
        {
            
        }
    }
}