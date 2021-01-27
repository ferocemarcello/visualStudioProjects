using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPractiseWebApi.Models
{
    public class AuctionItem
    {
        public AuctionItem(int itemNumber, string itemDescription, int ratingPrice, int bidPrice)
        {
            ItemNumber = itemNumber;
            ItemDescription = itemDescription;
            RatingPrice = ratingPrice;
            BidPrice = bidPrice;
            BidCustomName = null;
            BidCustomPhone = null;
            BidTimeStamp = default(DateTime);
        }
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public int RatingPrice { get; set; }
        public int BidPrice { get; set; }
        public string BidCustomName { get; set; }
        public string BidCustomPhone { get; set; }
        public DateTime BidTimeStamp { get; set; }
    }
}