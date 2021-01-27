using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel;
using System.Web;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuctionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuctionService.svc or AuctionService.svc.cs at the Solution Explorer and start debugging.
    //Default is creation of a new service-object per each call, but it might be changed
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] // Default
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]  // Remember to threadsafe
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)] //Demand wsHttpBinding

    /*[AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Required)] to use session*/
    public class AuctionService : IAuctionService
    {
        private static bool started = false;
        private static LinkedList<AuctionItem> items;
        Object objLock = new Object();
        public AuctionItem[] AllItems()
        {
            try { return items.ToArray(); }
            catch { return null; }
        }
        public AuctionItem ReadItem(int itemNumber)
        {
            foreach(var e in items)
            {
                //use HttpContext.Current for the application object
                /*if (int.Parse(HttpContext.Current.Session["count"].ToString()) == 0)
                {

                }*/
                if (e.ItemNumber == itemNumber) return e;
            }
            return null;
        }

        public void StartServer()
        {
            if (!started)
            {
                items = new LinkedList<AuctionItem>();
                items.AddLast(new AuctionItem(0, "a", 1000, 100));
                items.AddLast(new AuctionItem(1, "b", 2000, 200));
                items.AddLast(new AuctionItem(2, "c", 3000, 300));
                items.AddLast(new AuctionItem(3, "d", 4000, 400));
                items.AddLast(new AuctionItem(4, "e", 5000, 500));
                items.AddLast(new AuctionItem(5, "f", 6000, 600));
                started = true;
            }
        }
        public string Bid(Bid bid)
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
