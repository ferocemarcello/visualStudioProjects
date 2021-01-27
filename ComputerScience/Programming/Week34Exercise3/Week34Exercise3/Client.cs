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

                int i = new Random().Next(99);
                Console.WriteLine("i= " + i);
                if (i < 80)
                {
                    if (i > 40)
                    {
                        writer.WriteLine("Time?");
                        writer.Flush();
                    }
                    else
                    {
                        writer.WriteLine("Date?");
                        writer.Flush();
                    }
                    
                }
                else
                {
                    writer.WriteLine("Close");
                    online = false;
                    writer.Flush();
                    Console.WriteLine("The connection with the server is off ...\n");
                    writer.Close();
                    reader.Close();
                    stream.Close();
                    server.Close();
                }

                if (online)
                {
                    string serverData = reader.ReadLine();
                    Console.WriteLine("Server says: " + serverData);
                }
                
            }
            Console.ReadLine();
        }
        
    }
}
