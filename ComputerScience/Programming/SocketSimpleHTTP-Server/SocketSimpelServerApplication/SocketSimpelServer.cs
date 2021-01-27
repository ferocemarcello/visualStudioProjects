using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace SocketSimpelServerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketSimpleServer server = new SocketSimpleServer(11000);
            server.Run();
        }
    }

    class SocketSimpleServer
    {
        private IPAddress ip = IPAddress.Parse("127.0.0.1");
        private int port;
        private volatile bool stop = false;

        public SocketSimpleServer(int port)
        {
            this.port = port;
        }

        public void Run()
        {
            System.Console.WriteLine("Simpel server startet på port:" + port);

            TcpListener listener = new TcpListener(ip, port);
            listener.Start();

            while (!stop)
            {
                System.Console.WriteLine("Simpel server klar");

                // vent på en klient "kalder op" / "logger på"
                Socket clientSocket = listener.AcceptSocket();

                System.Console.WriteLine("Der er gået en i fælden");

                // opsæt input og output streams
                NetworkStream netStream = new NetworkStream(clientSocket);
                StreamWriter writer = new StreamWriter(netStream);
                StreamReader reader = new StreamReader(netStream);

                // læs data fra klient
                string request = reader.ReadLine();
                Console.WriteLine("Klient siger:" + request);
                switch (request)
                {
                    case "GET /date HTTP/1.1":
                        string datenow = DateTime.Now.ToShortDateString();
                        // HTTP HEADER
                        writer.WriteLine("HTTP/1.1 200 OK");
                        writer.WriteLine("Content-Type: text/plain");
                        writer.WriteLine("Content-Length: "+datenow.Length);
                        writer.WriteLine();

                        // scontent
                        writer.Write(datenow);
                        writer.Flush();
                        break;
                    default:
                        // HTTP HEADER
                        writer.WriteLine("HTTP/1.1 200 OK");
                        writer.WriteLine("Content-Type: text/plain");
                        writer.WriteLine("Content-Length: 10");
                        writer.WriteLine();

                        // skriv data til klient
                        writer.Write("Hej Klient");
                        writer.Flush();
                        break;

                }

                // luk forbindelse
                Console.WriteLine("Forbindelse til klient lukkes");
                writer.Close();
                reader.Close();
                netStream.Close();
                clientSocket.Close();
            }
        }
    }

}
