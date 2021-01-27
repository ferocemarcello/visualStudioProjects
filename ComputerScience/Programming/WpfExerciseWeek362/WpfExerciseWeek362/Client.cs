using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Controls;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace WpfExerciseWeek362
{
    class Client
    {
        private IPAddress serverIp;
        private int port;
        private TcpClient server;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private string sentText = "";
        private string receivedText = "";
        public Client(IPAddress serverIp, int port)
        {
            this.serverIp = serverIp;
            this.port = port;
            server = new TcpClient(serverIp.ToString(), port);
            stream = server.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
        }

        public void SendMessage(string text)
        {
            
            Thread t = new Thread(() => SendThread(text));
            t.Start();
            
        }
        public string ReceiveMessage()
        {
            
            
            Thread t = new Thread(ReceiveThread);
            t.Start();
            
            return this.receivedText;
        }
        private void ReceiveThread()
        {
            this.receivedText = reader.ReadLine();

        }
        private void SendThread(string text)
        {
            writer.WriteLine(text);
            writer.Flush();
        }
    }
}
