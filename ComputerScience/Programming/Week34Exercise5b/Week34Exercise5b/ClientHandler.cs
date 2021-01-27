using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerProject
{
    class ClientHandler
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
            string clientText = "";
            bool NumCorrect = true;
            while (true)
            {
               
                clientText = reader.ReadLine();                
                string[] words=new string[3];
                int first=-1;
                int second=-1;
                int result = 0;
                Console.WriteLine("Client says:" + clientText);
                try
                {
                    words = clientText.Split(' ');
                }
                catch (Exception)
                {
                    reader.Close();
                    writer.Close();
                    netStream.Close();
                    clientSocket.Close();
                    Console.WriteLine("Connection Closed");
                    Thread.CurrentThread.Abort();
                }
                if (clientText.Equals("exit"))
                {
                    reader.Close();
                    writer.Close();
                    netStream.Close();
                    clientSocket.Close();
                    Console.WriteLine("Connection Closed");
                    Thread.CurrentThread.Abort();
                }
                try
                {
                    first = int.Parse(words[1]);
                    second = int.Parse(words[2]);
                    NumCorrect = true;
                }
                catch (Exception)
                {
                    NumCorrect = false;
                }
                if (words.Length != 3 || (words[0].ToLower() != "add" && words[0].ToLower() != "sub")||!NumCorrect)
                {
                    writer.WriteLine("Wrong syntax");
                    writer.Flush();
                }
                else
                {
                    
                    if (words[0].ToLower().Equals("add"))
                    {
                        result = first + second;
                    }
                    if (words[0].ToLower().Equals("sub"))
                    {
                        result = first - second;
                    }
                    writer.WriteLine(result);
                    writer.Flush();
                }
            }
        }
    }
}
