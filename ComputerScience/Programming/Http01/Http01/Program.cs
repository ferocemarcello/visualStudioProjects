using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Http01
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 12000;
            Socket clientSocket;
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();
            clientSocket = listener.AcceptSocket();
            NetworkStream ns = new NetworkStream(clientSocket);
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            string text = sr.ReadLine();
            while(!(text.Equals("GET /date HTTP/1.1") || text.Equals("GET /klokken HTTP/1.1")))
            {
                sw.WriteLine("wrong input");
                sw.Flush();
                text = sr.ReadLine();
            }
            if(text.Equals("GET /date HTTP/1.1"))
            {
                sw.WriteLine("HTTP/1.1 200 OK\nContent - Type: text / plain\nContent - Length: "+DateTime.Today.ToString().Length+"\n\n" + DateTime.Today);
                sw.Flush();
            }
            if (text.Equals("GET /klokken HTTP/1.1"))
            {
                sw.WriteLine("HTTP/1.1 200 OK\nContent - Type: text / plain\nContent - Length: "+ DateTime.Now.ToString().Length + "\n\n" + DateTime.Now);
                sw.Flush();
            }
            sw.Close();
            sr.Close();
            ns.Close();
            clientSocket.Close();

        }
    }
}
