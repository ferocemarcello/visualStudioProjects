﻿using System;
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

        static void Main(string[] args)
        {
            System.Console.WriteLine("Simple server just started at port: " + port);
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();

            while (true)
            {
                System.Console.WriteLine("Simple Server Ready");
                Socket clientSocket = listener.AcceptSocket();
                System.Console.WriteLine("New Socket Created, a new connection established with a client");
                Console.WriteLine("My ip and port are: "+clientSocket.LocalEndPoint.ToString());
                Console.WriteLine("Ready");
                NetworkStream netStream = new NetworkStream(clientSocket);
                StreamWriter writer = new StreamWriter(netStream);
                StreamReader reader = new StreamReader(netStream);

                string clientText = reader.ReadLine();
                Console.WriteLine("Client says:" + clientText);
                if (clientText.Equals("Time?"))
                {
                    writer.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
                }
                else
                {
                    writer.WriteLine("Unknown command");
                }
                
                writer.Flush();

                Console.WriteLine("Connection with the client closes");
                writer.Close();
                reader.Close();
                netStream.Close();
                clientSocket.Close();
            }
        }
    }
}
