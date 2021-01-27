using System.Net.Sockets;

namespace AuctionHouseProject
{
    public class Item
    {
        private string name;
        private int price;
        private User lastBidder;
        private Socket lastSocket;
        public Item(string name, int price, User lastBidder,Socket lastSocket)
        {
            this.name = name;
            this.price = price;
            this.lastBidder = lastBidder;
            this.lastSocket = lastSocket;
        }
        public Item(string name, int price)
        {
            this.name = name;
            this.price = price;
            this.lastBidder = null;
            this.lastSocket = null;
        }
        public string getName()
        {
            return this.name;
        }
        public int getPrice()
        {
            return this.price;
        }
        public User getLastBidder()
        {

            return this.lastBidder;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setPrice(int price)
        {
            this.price = price;
        }
        public void setLastBidder(User bidder)
        {
            this.lastBidder = bidder;
        }
        public void setLastSocket(Socket socket)
        {
            this.lastSocket = socket;
        }
        public Socket getLastSocket()
        {
            return this.lastSocket;
        }
    }
}