using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerProject
{
    public class Server
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        public int numberOfClients { get; set; }
        private Object numberOfClientsLock = new Object();
        private static Server singleton;
        private Server()
        {
            try
            {
                Ip = Server.GetLocalIPAddress();
            }
            catch
            {
                Ip = "127.0.0.1";
            }
            Port = 11800;
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        public static Server getServerObject()
        {
            if(Server.singleton == default(Server))
            {
                singleton = new Server();
            }
            return Server.singleton;
        }

        public void Run(Socket clientSocket)
        {
            NetworkStream n = new NetworkStream(clientSocket);
            StreamReader sr = new StreamReader(n);
            StreamWriter sw = new StreamWriter(n);
            lock (this.numberOfClientsLock) { ++this.numberOfClients; }
            sw.AutoFlush = true;
            this.HelloMessage(sw);
            bool goodbye = false;
            while (!goodbye)
            {
                string s = sr.ReadLine();
                switch (s)
                {
                    case "bye":
                        this.CloseClient(sw, sr, n, clientSocket, ref goodbye);
                        break;
                    default : this.ErrorMessage(sw); break;
                }
            }
        }

        private void CloseClient(StreamWriter sw, StreamReader sr, NetworkStream n, Socket clientSocket, ref bool goodbye)
        {
            lock (this.numberOfClientsLock) { --numberOfClients; }
            goodbye = true;
            sw.WriteLine("good bye client");
            sw.Close();
            sr.Close();
            n.Close();
            clientSocket.Shutdown(SocketShutdown.Both);
            //If uncomment the line below, it works so that when there are no more clients, the server shuts down
            //lock (this.numberOfClientsLock) { if (this.numberOfClients == 0) ServerProject.Program.EndServer(); }
            Thread.CurrentThread.Abort();
        }

        private void ErrorMessage(StreamWriter sw)
        {
            sw.WriteLine("Wrong input,retype");
        }

        private void HelloMessage(StreamWriter sw)
        {
            sw.WriteLine("Hello Client");
            sw.WriteLine("Remember to write 'bye' to go out");
            sw.WriteLine("Write here your commands");
        }
    }
}
