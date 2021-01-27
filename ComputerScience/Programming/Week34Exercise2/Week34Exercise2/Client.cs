using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Week34Exercise2
{
    class Client
    {
        private static string servername = "127.0.0.1";
        private static int port = 11000;
        static void Main(string[] args)
        {
            System.Console.WriteLine("Simple Client just Started. Server ip/name: " + servername + " Server port:" + port);
            TcpClient server = new TcpClient(servername, port);
            Console.WriteLine("My ip and port are: " + server.Client.LocalEndPoint.ToString());
            NetworkStream stream = server.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine("Time?");
            writer.Flush();
            string serverData = reader.ReadLine();
            Console.WriteLine("Server says: " + serverData); 

            Console.WriteLine("The connection with the server is off ...\n");
            writer.Close();
            reader.Close();
            stream.Close();
            server.Close();

            Console.ReadLine();
        }
    }
}
