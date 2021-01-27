using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PractiseExamSocket
{
    class Program
    {
        public static bool isProgramOver = false;
        /*simple example about delegates and event
        public delegate double MathAction(double num);
        public static double DoubleOp(double input)//put static because here
        {
            return input * 2;
        }
        public static double TrebleOp(double input)//put static because here
        {
            return input * 3;
        }
        public static MathAction ma = DoubleOp;//put static because here
        public double FourmultByTwo = ma(4);
        public static event MathAction MyEvent;//put static because here*/

        public static void Main()
        {
            /*MyEvent += DoubleOp;//see here the instance of delegate is not used
            MyEvent += TrebleOp;//obviously the*/
            Server s = Server.getServerObject();
            TcpListener listener = new TcpListener(IPAddress.Parse(s.ip), s.port);
            System.Console.WriteLine("Simple server just started at location: " + s.ip + ":" + s.port);
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
                t = new Thread(new ThreadStart(() => Server.getServerObject().Run(clientSocket)));
                t.Start();
            }
        }
    }
}
