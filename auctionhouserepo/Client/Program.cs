using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        private static string ip;
        private static int port;

        static void Main(string[] args)
        {

            Console.WriteLine("Type 'custom' to decide ip and port, 'default' for default");

            if (Console.ReadLine().Equals("custom"))
                CustomServerSetup();
            else
                DefaultServerSetup();
            
            Client client = new Client(ip, port);
            client.Run();

            Console.ReadKey();
        }

        private static void DefaultServerSetup()
        {
            ip = "127.0.0.1";
            port = 11000;
            Console.WriteLine("You chose default server settings");
            Console.WriteLine("ip = " + ip);
            Console.WriteLine("port = " + port);
        }

        private static void CustomServerSetup()
        {
            Console.Write("Insert server IP: ");
            ip = Console.ReadLine();

            Console.Write("Insert port: ");
            try
            {
                port = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                port = 11000;
                Console.WriteLine("port set to " + port);
            }
        }

    }
}