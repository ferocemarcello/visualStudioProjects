using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace AuctionHouseProject
{
    public class AuctionHouse
    {
        public static bool isAuctionOver = false;
        public static void Main(string[] args)
        {
            Server s = Server.getServerObject();
            TcpListener listener = new TcpListener(IPAddress.Any /*s.getServerIp()*/, s.getServerPort());
            System.Console.WriteLine("Simple server just started at location: " + s.getServerIp() + ":" + s.getServerPort());
            System.Console.WriteLine("Simple Server Ready, The Auction House is open");
            listener.Start();
            Socket clientSocket;
            Thread t;
            while (!isAuctionOver)
            {

                clientSocket = listener.AcceptSocket();
                t = new Thread(new ThreadStart(() => Server.getServerObject().checkUser(clientSocket, s)));
                t.Start();
            }
        }
    }
}


