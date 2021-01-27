using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        private static int port = 11000;
        private static IPAddress ip = IPAddress.Parse("127.0.0.1");
        private static bool online = true;
        static void Main(string[] args)
        {
            System.Console.WriteLine("Simple server just started at port: " + port);
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();
            System.Console.WriteLine("Simple Server Ready");
            Socket clientSocket = listener.AcceptSocket();
            System.Console.WriteLine("New Socket Created, a new connection established with a client");
            Console.WriteLine("My ip and port are: " + clientSocket.LocalEndPoint.ToString());
            Console.WriteLine("Ready");
            NetworkStream netStream = new NetworkStream(clientSocket);
            StreamWriter writer = new StreamWriter(netStream);
            StreamReader reader = new StreamReader(netStream);
            string clientText;
            string[] words;
            int first;
            int second;
            int result=0;
            while (online)
            {


                clientText = reader.ReadLine();
                Console.WriteLine("Client says:" + clientText);
                words = clientText.Split(' ');
                if (clientText.Equals("exit"))
                {
                    reader.Close();
                    writer.Close();
                    netStream.Close();
                    clientSocket.Close();
                    Console.WriteLine("Connection Closed");
                    online = false;
                    break;
                }
                if (words.Length != 3||(words[0]!="add"&&words[0]!="sub"))
                {
                    Console.WriteLine("Wrong syntax");
                }
                else
                {
                    first = int.Parse(words[1]);
                    second = int.Parse(words[2]);
                    if (words[0].Equals("add"))
                    {
                        result = first + second;
                    }
                    if (words[0].Equals("sub"))
                    {
                        result = first - second;
                    }
                        writer.WriteLine(result);
                        writer.Flush();
                }
            }
            Console.ReadLine();
        }
    }
}
