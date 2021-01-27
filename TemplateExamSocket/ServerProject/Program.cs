using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerProject
{
    public class Program
    {
        private volatile static bool isProgramOver = false;
        public static void Main(string[] args)
        {
            Server s = Server.getServerObject();
            TcpListener listener = new TcpListener(IPAddress.Parse(s.Ip), s.Port);
            System.Console.WriteLine("Simple server just started at location: " + s.Ip + ":" + s.Port);
            System.Console.WriteLine("Simple Server Ready");
            listener.Start();
            Socket clientSocket;
            Thread t;
            while (!isProgramOver)
            {
                clientSocket = listener.AcceptSocket();
                /* other way to run a parameterized thread
                t = new Thread(new ParameterizedThreadStart(Server.getServerObject().Run));//the parameter of the method has to be void in this case
                t.Start(clientSocket);*/
                t = new Thread(new ThreadStart(() => s.Run(clientSocket)));
                t.Start();
            }
        }

        public static void EndServer()
        {
            isProgramOver = true;
        }
    }
}
