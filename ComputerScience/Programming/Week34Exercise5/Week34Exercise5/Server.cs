using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerProject
{
    
    public class Server
    {
        private int port;
        private IPAddress ip;
        public Server(int port)
        {
            this.port = port;
            this.ip= IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(this.ip, this.port);
            System.Console.WriteLine("Simple server just started at port: " + this.port);
            System.Console.WriteLine("Simple Server Ready");
            listener.Start();
            Thread t;
            Socket clientSocket;
            while (true)
            {
                clientSocket = listener.AcceptSocket();
                ClientHandler handler = new ClientHandler();
                t = new Thread(new ThreadStart(() => handler.RunClient(clientSocket)));
                t.Start();
            }
        }
    }
    
}
