using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SocketServer;


namespace SocketProgram
{
    public class Client
    {
        public static IPEndPoint clientIpe = new IPEndPoint(IPAddress.Loopback, 11000);
        static void Main(string[] args)
        {
            Socket sc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipAddress = IPAddress.Loopback;
            

            try
            {
                sc.Connect(Server.serverIpe);
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine("ArgumentNullException : {0}", ae.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

            byte[] msg = System.Text.Encoding.ASCII.GetBytes("request");
            int bytesSent = sc.Send(msg);
            Console.WriteLine("bytes sent to " + Server.serverIpe.Port);
            byte[] bytes = new byte[1024];
            int bytesRec = sc.Receive(bytes);
            Console.WriteLine("bytes received from " + Server.serverIpe.Port);
            Console.WriteLine("Echoed text = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));
            Console.WriteLine("Closing");
            sc.Shutdown(SocketShutdown.Both);
            sc.Close();
            Console.ReadLine();
        }
    }
}
