using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TemplateExamWebApi.Models;

namespace TemplateExamWebApi.Controllers
{
    public class ServerController : ApiController
    {
        private static List<Item> items;
        private Object lockOnItems = new Object();
        static ServerController()
        {
            InitFields();
        }
        [HttpGet]
        public List<Item> AllItems()
        {
            return items;
        }
        [HttpGet]
        public Item ReadItem(int itemNumber)
        {
            return items.Find(i => i.ItemNumber == itemNumber);
        }
        [HttpPost]
        public string Do([FromBody]Item item)
        {
            /*var httpContext = Request.Properties["MS_HttpContext"] as System.Web.HttpContextWrapper;//to use session
            httpContext.Application.Lock();
            lock and unlock to lock and unlock
            httpContext.Session["Operations"] == null
            httpContext.Application.UnLock();*/
            return "done";
        }
        private static void InitFields()
        {
            throw new NotImplementedException();
        }
    }
}
