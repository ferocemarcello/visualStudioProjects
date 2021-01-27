using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Week34Exercise3
{
    class Client
    {
        private static string servername = "127.0.0.1";
        private static int port = 11000;
        public static bool online = true;
        static void Main(string[] args)
        {
            System.Console.WriteLine("Simple Client just Started. Server ip/name: " + servername + " Server port:" + port);
            TcpClient server = new TcpClient(servername, port);
            Console.WriteLine("My ip and port are: " + server.Client.LocalEndPoint.ToString());
            NetworkStream stream = server.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            while (online)
            {

            }
            Console.ReadLine();
        }

    }
}
