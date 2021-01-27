using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PractiseExamSocket
{
    public class Server
    {
        public int port { get; set; }
        public string ip { get; set; }
        private static Server serverObject = new Server(11800, Server.GetLocalIPAddress());
        private int numberOfClients = 0;

        private Server(int portp,string ipp)
        {
            port = portp;
            ip = ipp;
        }

        public static string GetLocalIPAddress()
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
            return Server.serverObject;
        }

        public void Run(Socket s)
        {
            NetworkStream n = new NetworkStream(s);
            StreamReader sr = new StreamReader(n);
            StreamWriter sw = new StreamWriter(n);
            ++this.numberOfClients;
            sw.AutoFlush = true;
            bool goodbye = false;
            sw.WriteLine("Hello Client");
            sw.WriteLine("Write the directory you want to have informations about");
            sw.WriteLine("Remember to write 'bye' to go out");
            string st = sr.ReadLine();
            //if (st == "bye") goodbye = true;
            while (!goodbye)
            {
                if (st == "bye")
                {
                    --numberOfClients;
                    goodbye = true;
                    sw.WriteLine("good bye client");
                    sw.Close();
                    sr.Close();
                    n.Close();
                    s.Shutdown(SocketShutdown.Both);
                    //If uncomment the line below, it works so that when there are no more clients, the server shuts down
                    //if (this.numberOfClients == 0) PractiseExamSocket.Program.isProgramOver = true;
                    Thread.CurrentThread.Abort();
                }
                
                else
                {

                    DirectoryInfo dir = new DirectoryInfo(st);
                    
                    if (dir.Exists)
                    {
                        sw.WriteLine("date or subdirectories?");
                        if (sr.ReadLine() == "date")
                        {
                            sw.WriteLine("the directory exists. The creation date is" + dir.CreationTime.ToLongDateString());
                        }
                        else
                        {
                            if(sr.ReadLine() == "subdirectories")
                            {
                                LinkedList<string> subs = new LinkedList<string>();
                                foreach (var d in dir.GetDirectories()) subs.AddLast(d.ToString());
                                sw.WriteLine("the directory exists. All subdirectories are: ");
                                foreach (var v in subs) sw.WriteLine(v);
                            }
                            else
                            {
                                sw.WriteLine("invalid command");
                            }
                        }
                        
                        
                        
                    }
                    else sw.WriteLine("the directory doesn't exists");
                    st = sr.ReadLine();
                }
                
            }
            
        }
    }
}
