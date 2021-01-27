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
    public class ClientHandler
    {
        private void CloseConnection(Socket clientSocket,NetworkStream n,StreamWriter w, StreamReader r)
        {
            w.Close();
            r.Close();
            n.Close();
            clientSocket.Close();
        }
        public void RunClient(Socket clientSocket,GuessNumber g)
        {
            int remainingAttempts = 10;
            NetworkStream netStream = new NetworkStream(clientSocket);
            StreamWriter writer = new StreamWriter(netStream);
            StreamReader reader = new StreamReader(netStream);
            writer.AutoFlush = true;
            writer.WriteLine("New Socket Created, a new connection established with a client: " + clientSocket.RemoteEndPoint.ToString());
            writer.WriteLine("Ready");
            writer.WriteLine("Guess a number beetween 1 and 10; you have" + remainingAttempts + "attempts");
            string clientText = "";
            int attempt = 0;
            while (true)
            {
                
                try
                {
                    clientText = reader.ReadLine();
                }
                catch
                {
                    this.CloseConnection(clientSocket,netStream,writer,reader);
                    Thread.CurrentThread.Abort();
                }
                
                
                writer.WriteLine("Client " + clientSocket.RemoteEndPoint.ToString() + " says:" + clientText);
                writer.Flush();
                bool goodSyntax = false;
                while (!goodSyntax)
                {
                    try
                    {
                        attempt = int.Parse(clientText);
                        goodSyntax = true;
                    }
                    catch
                    {
                        goodSyntax = false;
                    }
                }
                if (attempt == g.getNumber())
                {
                    writer.WriteLine("You won, try again?");
                    writer.Flush();
                    string text = "";
                    try
                    {
                        text = reader.ReadLine();
                    }
                    catch (Exception)
                    {
                        this.CloseConnection(clientSocket, netStream, writer, reader);
                        Thread.CurrentThread.Abort();
                    }

                    if (text.Equals("y"))
                    {
                        g.setNewNumber();
                        remainingAttempts = 10;
                    }
                    else
                    {
                        this.CloseConnection(clientSocket, netStream, writer, reader);
                        Console.WriteLine("Connection Closed");
                        Thread.CurrentThread.Abort();

                    }

                }
                else
                {

                    remainingAttempts--;
                    if (remainingAttempts == 0)
                    {
                        
                        writer.WriteLine("No more attempts, Connection Closed");
                        writer.Flush();
                        this.CloseConnection(clientSocket, netStream, writer, reader);
                        Thread.CurrentThread.Abort();
                    }
                    writer.WriteLine("You was wrong, retry");
                    writer.Flush();
                    

                }
            }
        }
    }
}
