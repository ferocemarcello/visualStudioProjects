using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client
{
    class Client
    {
        private string serverIp;
        private int port;

        TcpClient socket;
        
        private NetworkStream netStream;
        private StreamWriter write;
        private StreamReader read;

        bool exit;

        public Client(string serverIp, int port)
        {
            this.serverIp = serverIp;
            this.port = port;
            exit = false;
        }

        public void Run()
        {
            Console.WriteLine("Client for auction house");

            try
            {
                socket = new TcpClient(serverIp, port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
         
            netStream = socket.GetStream();
            write = new StreamWriter(netStream);
            read = new StreamReader(netStream);

            Thread writeThread = new Thread(Write);
            writeThread.Start();

            Thread readThread = new Thread(Read);
            readThread.Start();

            while (!exit) ;

            write.Close();
            read.Close();
            netStream.Close();

            socket.Close();
            
        }

        private void Read()
        {
            Console.WriteLine("Read thread started");
            while (!exit)
            {
                Console.WriteLine(read.ReadLine());
            }
        }

        private void Write()
        {
            while (!exit)
            {
                Console.Write("Send a message to the server ('bye' to exit): ");
                string s = Console.ReadLine();
                if (s.Equals("bye"))
                   exit = true;
                write.WriteLine(s);
                write.Flush();
                Console.WriteLine("Message sent.");
            }
        }

    }
}
