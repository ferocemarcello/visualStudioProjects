using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public class Server
    {
        public static IPEndPoint serverIpe = new IPEndPoint(IPAddress.Loopback, 11000);
        static void Main(string[] args)
        {
            Socket ss = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine(serverIpe.Port);

            ss.Bind(serverIpe);
            Console.WriteLine("binding done");
                ss.Listen(100);
            Console.WriteLine("server socket in Listen state");
            Console.WriteLine("new server socket created waiting for a connection...");
            Socket handler = ss.Accept();
                String data = null;
                
               
                
                    var bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    
            
                Console.WriteLine("Text received: "+ data);
                if(data.Equals("request"))
            {
                Console.WriteLine("This is a request");
            }
                else
            {
                Console.WriteLine("This is a stupid normal message");
            }
                byte[] msg = Encoding.ASCII.GetBytes("test received");
                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            Console.WriteLine("Connection close by server");

            Console.ReadLine();

            
            
            
            
               
            
            
            
            //Console.ReadLine();
        }
    }
}
