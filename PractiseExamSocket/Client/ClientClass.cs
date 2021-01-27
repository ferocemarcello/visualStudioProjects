using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public class ClientClass
    {
        private string ip;
        private int port;
        private TcpClient socket;
        private NetworkStream netStream;
        private StreamWriter write;
        private StreamReader read;
        volatile bool exit = false;

        public ClientClass(string ip, string port)
        {
            this.ip = ip;
            this.port = int.Parse(port);
        }

        public void Run()
        {
            try
            {
                socket = new TcpClient(ip, port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
            netStream = socket.GetStream();
            write = new StreamWriter(netStream);
            write.AutoFlush = true;
            read = new StreamReader(netStream);
            Thread readThread = new Thread(Read);
            readThread.Start();
            while (!exit)
            {
                string s = Console.ReadLine();
                write.WriteLine(s);
                if (s == "bye") exit = true;
            }
            write.Close();
            read.Close();
            netStream.Close();
            socket.Close();
        }

        private void Read()
        {
            while (!exit)
            {
                Console.WriteLine(read.ReadLine());
            }
        }
    }
}