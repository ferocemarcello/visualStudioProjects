using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PractiseExamSocket;

namespace Client
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("type ip");
            string ip = Console.ReadLine();
            Console.WriteLine("type PORT");
            string port = Console.ReadLine();
            ClientClass client = new ClientClass(ip, port);
            client.Run();
        }
    }
}
