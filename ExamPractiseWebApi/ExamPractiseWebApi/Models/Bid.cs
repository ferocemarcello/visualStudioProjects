using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPractiseWebApi.Models
{
    public class Bid
    {
        public int ItemNumber { get; set; }
        public int Price { get; set; }
        public string CustomName { get; set; }
        public string CustomPhone { get; set; }
        /*public Bid()
        {

        }*/
        public Bid(int itemNumber, int price, string name, string phone)
        {
            ItemNumber = itemNumber;
            Price = price;
            CustomName = name;
            CustomPhone = phone;
        }
    }
}