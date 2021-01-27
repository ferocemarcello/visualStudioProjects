using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientProject
{
    public class Client
    {
        private string ip;
        private int port;
        private volatile bool exit;
        TcpClient socket;
        NetworkStream netStream;
        public Client(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }
        public void Run()
        {
            try
            {
                socket = new TcpClient(ip, port);
                StartEndConversation(socket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }
        private void StartEndConversation(TcpClient socket)
        {
            netStream = this.socket.GetStream();
            exit = false;
            StreamReader reader = new StreamReader(netStream);
            Thread readThread = new Thread(new ParameterizedThreadStart(Read));
            readThread.Start(reader);
            StreamWriter writer = new StreamWriter(netStream);
            Thread writeThread = new Thread(new ParameterizedThreadStart(Write));
            writeThread.Start(writer);
            readThread.Join();
            writeThread.Join();
            CloseConnection();
        }
        private void CloseConnection()
        {
            netStream.Close();
            socket.Close();
        }
        private void Write(object streamWriter)
        {
            StreamWriter writer = (StreamWriter)streamWriter;
            writer.AutoFlush = true;
            while (!exit)
            {
                string s = Console.ReadLine();
                try { writer.WriteLine(s); } catch { exit = true; }
                if (s == "bye") exit = true;
            }
            writer.Close();
        }
        private void Read(object streamReader)
        {
            StreamReader reader = (StreamReader)streamReader;
            while (!exit)
            {
                try { Console.WriteLine(reader.ReadLine()); } catch { exit = true; }
            }
            reader.Close();
        }
    }
}
