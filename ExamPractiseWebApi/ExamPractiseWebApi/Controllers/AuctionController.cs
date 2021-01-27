using ExamPractiseWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamPractiseWebApi.Controllers
{
    public class AuctionController : ApiController
    {
        List<AuctionItem> items;
        private static Object objLock = new Object();
        private bool InitItems()
        {
            if (items != null) return false;
            items = new List<AuctionItem>();
            items.Add(new AuctionItem(0, "a", 1000, 100));
            items.Add(new AuctionItem(1, "b", 2000, 200));
            items.Add(new AuctionItem(2, "c", 3000, 300));
            items.Add(new AuctionItem(3, "d", 4000, 400));
            items.Add(new AuctionItem(4, "e", 5000, 500));
            items.Add(new AuctionItem(5, "f", 6000, 600));
            return true;
        }
        [HttpGet]
        public List<AuctionItem> AllItems()
        {
            InitItems();
            return items;
        }
        [HttpGet]
        public AuctionItem ReadItem(int itemNumber)
        {
            InitItems();
            foreach (var e in items)
            {
                if (e.ItemNumber == itemNumber) return e;
            }
            return null;
        }
        public string PostBid([FromBody]Bid bid)
        {
            AuctionItem i = ReadItem(bid.ItemNumber);
            if (i == null) return "item not found";

            lock (objLock)
            {
                if (bid.Price > i.BidPrice)
                {
                    i.BidPrice = bid.Price;
                    i.BidCustomName = bid.CustomName;
                    i.BidCustomPhone = bid.CustomPhone;
                    i.BidTimeStamp = DateTime.Now;
                    return "ok";
                }
                else return "bid too low";
            }
        }
    }
}
