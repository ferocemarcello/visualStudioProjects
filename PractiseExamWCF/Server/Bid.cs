using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Server
{
    [DataContract]
    public class Bid
    {
        [DataMember]
        public int ItemNumber { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public string CustomName { get; set; }
        [DataMember]
        public string CustomPhone { get; set; }
        public Bid(int itemNumber,int price,string name, string phone)
        {
            ItemNumber = itemNumber;
            Price = price;
            CustomName = name;
            CustomPhone = phone;
        }
    }
}