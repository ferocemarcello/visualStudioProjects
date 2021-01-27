using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Server
{
    [DataContract]
    public class AuctionItem
    {
        public AuctionItem(int itemNumber,string itemDescription, int ratingPrice, int bidPrice)
        {
            ItemNumber = itemNumber;
            ItemDescription = itemDescription;
            RatingPrice = ratingPrice;
            BidPrice = bidPrice;
            BidCustomName = null;
            BidCustomPhone = null;
            BidTimeStamp = default(DateTime);
        }
        [DataMember]
        public int ItemNumber { get; set; }
        [DataMember]
        public string ItemDescription{ get; set; }
        [DataMember]
        public int RatingPrice { get; set; }
        [DataMember]
        public int BidPrice { get; set; }
        [DataMember]
        public string BidCustomName { get; set; }
        [DataMember]
        public string BidCustomPhone { get; set; }
        [DataMember]
        public DateTime BidTimeStamp { get; set; }
    }
}