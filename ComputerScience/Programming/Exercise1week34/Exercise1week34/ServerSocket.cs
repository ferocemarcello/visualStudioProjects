using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise1week34
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerSocket server = new ServerSocket(11000);
            server.Run();
        }
    }
    class ServerSocket
    {
        private IPAddress ip = IPAddress.Parse("127.0.0.1");
        private int port;
        private volatile bool stop = false;
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 11000);
        Socket clientSocket;
        NetworkStream netStream;
        StreamWriter writer; 
        StreamReader reader;

        public ServerSocket(int port)
        {
            this.port = port;
            
        }
        private void ReceiveThread()
        {
            while (true)
            {
                textReceived = reader.ReadLine();
                Console.WriteLine("Client says:" + textReceived);
                if (textReceived.Equals("bye"))
                {
                    writer.Close();
                    reader.Close();
                    netStream.Close();
                    clientSocket.Close();
                    Thread.CurrentThread.Abort();
                }
            }
            
        }
        private void SendThread()
        {
            while (true)
            {
                writer.WriteLine("hi client");
                writer.Flush();
                
            }

        }
        string textReceived = "";
        string textSent = "";
        public void Run()
        {
            
            System.Console.WriteLine("Simple server just started at port: " + port);

            
            listener.Start();

            
                System.Console.WriteLine("Simple Server Ready");

                // vent på en klient "kalder op" / "logger på"
                this.clientSocket = listener.AcceptSocket();
            this.netStream = new NetworkStream(clientSocket);
            this.writer = new StreamWriter(netStream);
            this.reader = new StreamReader(netStream);

            System.Console.WriteLine("New Socket Created, a new connection established with a client");
                Console.WriteLine(clientSocket.LocalEndPoint.ToString());
                // opsæt input og output streams
                

                // læs data fra klient
                writer.WriteLine("Hello Client");
                writer.Flush();
                
                Thread t = new Thread( ReceiveThread);
                t.Start();
            Thread t2 = new Thread(SendThread);
            t2.Start();









            // skriv data til klient

            // luk forbindelse
            /*Console.WriteLine("Connection with the client closes");
            writer.Close();
            reader.Close();
            netStream.Close();
            clientSocket.Close();*/

        }

        
    }
}
