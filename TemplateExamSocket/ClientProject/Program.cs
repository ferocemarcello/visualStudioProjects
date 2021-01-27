using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProject
{
    public class Program
    {
        public static void Main(string[] Args)
        {
            Console.WriteLine("type ip");
            string ip = Console.ReadLine();
            Console.WriteLine("type PORT");
            string port = Console.ReadLine();
            Client client = new Client(ip, int.Parse(port));
            client.Run();
        }
    }
}
