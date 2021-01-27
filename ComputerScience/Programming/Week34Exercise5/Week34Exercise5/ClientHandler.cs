using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace ServerProject
{
    public class ClientHandler
    {
        public void RunClient(Socket clientSocket)
        {
            
            NetworkStream netStream = new NetworkStream(clientSocket);
            StreamWriter writer = new StreamWriter(netStream);
            StreamReader reader = new StreamReader(netStream);
            writer.WriteLine("New Socket Created, a new connection established with a client: " + clientSocket.RemoteEndPoint.ToString());
            writer.Flush();
            writer.WriteLine("Ready");
            writer.Flush();
            string clientText="";
            while (true)
            {
                try
                {
                    clientText = reader.ReadLine();
                }
                catch (Exception)
                {
                    writer.Close();
                    reader.Close();
                    netStream.Close();
                    clientSocket.Close();
                    Thread.CurrentThread.Abort();
                }
                Console.WriteLine("Client says:" + clientText);
                switch (clientText.ToLower())
                {
                    case "time":
                        {
                            writer.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
                            writer.Flush();
                            break;
                        }
                    case "date":
                        {
                            writer.WriteLine(DateTime.Today.ToString());
                            writer.Flush();
                            break;
                        }
                    case "close":
                        {
                            writer.Flush();
                            Console.WriteLine("Connection with the client closes");
                            writer.Close();
                            reader.Close();
                            netStream.Close();
                            clientSocket.Close();
                            Thread.CurrentThread.Abort();
                            break;
                        }
                    default:
                        {
                            writer.WriteLine("Unknown command");
                            writer.Flush();
                            break;
                        }
                }
            }
        }
    }
}