using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientSocket client = new ClientSocket("127.0.0.1", 11000);
            client.Run();
        }
    }
    class ClientSocket
    {
        private string servername;
        private int port;

        public ClientSocket(string servername, int port)
        {
            this.servername = servername;
            this.port = port;
        }
        public void Run()
        {
            System.Console.WriteLine("Simple Client just Started. Server ip/name: " + servername + " Server port:" + port);

            //// Instantiér socket - forbinder socket til server
            TcpClient server = new TcpClient(servername, port);
            Console.WriteLine("My ip and port are: " + server.Client.LocalEndPoint.ToString());
            // opsæt input og output streams
            NetworkStream stream = server.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            // send besked til server
            writer.WriteLine("Hello Server"); // Skriver tekst til serveren
            writer.Flush(); // Tømmer tcp-bufferen

            // læs svar fra server
            string serverData = reader.ReadLine(); // Læser besked fra server
            Console.WriteLine("Server says: "+serverData); // Skriver besked til skærmen

            Console.WriteLine("The connection with the server is off ...\n");
            writer.Close();
            reader.Close();
            stream.Close();
            server.Close();

            Console.ReadLine(); // vent på retur
        }
    }
}
