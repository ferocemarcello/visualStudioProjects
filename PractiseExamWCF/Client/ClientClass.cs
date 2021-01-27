using System;
using Client.ServiceReference1;
using System.Threading;

namespace Client
{
    public class ClientClass
    {
        private AuctionServiceClient cl;
        private string phone;
        private string name;

        public ClientClass(AuctionServiceClient cl)
        {
            this.cl = cl;
        }

        public void Run()
        {
            cl.StartServer();
            Console.WriteLine("your name");
            name = Console.ReadLine();
            Console.WriteLine("your phone");
            phone = Console.ReadLine();
            Thread bid = new Thread(Bid);
            bid.Start();
        }

        private void Bid()
        {
            while (true)
            {
                Console.WriteLine("write item number");
                string i = Console.ReadLine();
                Console.WriteLine("write price");
                string p = Console.ReadLine();
                Console.WriteLine(cl.Bid(new Bid(i, p, name, phone)));
            }
        }
    }
}