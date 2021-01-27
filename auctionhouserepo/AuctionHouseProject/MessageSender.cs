using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouseProject
{
    class MessageSender
    {
        private Socket clientSocket;

        public MessageSender(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
        }
        public Socket getClientSocket()
        {
            return this.clientSocket;
        }
        public void setClientSocket(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
        }
        public void SendMessage(string text)
        {
            NetworkStream n = new NetworkStream(clientSocket);
            StreamWriter sw = new StreamWriter(n);
            sw.WriteLine(text);
            sw.Flush();
            sw.Close();
            n.Close();
        }
    }
}
