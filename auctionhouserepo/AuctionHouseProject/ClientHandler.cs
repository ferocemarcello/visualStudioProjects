using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionHouseProject
{
    class ClientHandler
    {
        private Socket clientSocket;
        private NetworkStream ns;
        private StreamReader sr;
        private StreamWriter sw;
        private User user;
        MessageSender ms;

        public ClientHandler(Socket clientSocket, User u)
        {
            this.clientSocket = clientSocket;
            this.ns = new NetworkStream(clientSocket);
            this.sr = new StreamReader(ns);
            this.sw = new StreamWriter(ns);
            ms = new MessageSender(clientSocket);
            this.user = u;
        }

        public ClientHandler(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            this.ns = new NetworkStream(clientSocket);
            this.sr = new StreamReader(ns);
            this.sw = new StreamWriter(ns);
            ms = new MessageSender(clientSocket);
        }

        public MessageSender GetMs()
        {
            return this.ms;
        }

        public void WelcomeMessage()
        {
            Item i = Server.getServerObject().getGoodList().First();
            sw.WriteLine("welcome to the auction house." + user.getEmail() + " You have a balance of " + user.getBalance() + " dkk");
            sw.WriteLine("the item which is being sold is a " + i.getName() + " for a price at the moment of " + i.getPrice());
            sw.WriteLine("Type 'bid -amount-' to bid");
            sw.WriteLine("Type 'bye' to leave");
            sw.Flush();
        }

        public void CheckUser()
        {
            Thread t;
            bool closed = false;
            bool signUp = FirstApproach(ref sr, ref sw,ref closed);
            if (closed)
            {
                this.CloseUser();
            }
            bool correctCredentials = true;
            User u = null;
            do
            {
                string[] words = AskCredentials(sr, sw);

                if (words == null)
                {
                    this.CloseUser();
                }

                if (signUp)
                {

                    int balance = AskBalance(sr, sw);
                    if (balance == -1)
                    {
                        this.CloseUser();
                    }
                    u = new User(words[0], words[1], balance);
                    try
                    {
                        Server.getServerObject().getInvoker().CreateUser(u);
                        correctCredentials = true;
                    }
                    catch (Exception e)
                    {
                        correctCredentials = false;
                        sw.WriteLine("You can't sign up due to this Exception");
                        sw.Flush();
                        sw.WriteLine(e.GetType());
                        sw.Flush();
                    }
                }
                else
                {
                    bool isUserIn = Server.getServerObject().CkeckMatchingMailAndPassword(words[0], words[1]);
                    if (isUserIn)
                    {
                        u = new User(words[0], words[1], Server.getServerObject().getUserBalance(words[0]));
                    }
                    while (!isUserIn)
                    {
                        words = AskCredentials(sr, sw);
                        isUserIn = Server.getServerObject().CkeckMatchingMailAndPassword(words[0], words[1]);
                        u = new User(words[0], words[1], Server.getServerObject().getUserBalance(words[0]));
                    }
                    correctCredentials = true;
                }
            }
            while (!correctCredentials);

            Server.getServerObject().addUser(u);
            t = new Thread(new ThreadStart(() => Server.getServerObject().Connection(u, clientSocket)));
            t.Start();
        }
        private int AskBalance(StreamReader sr, StreamWriter sw)
        {
            sw.WriteLine("Tell me your balance");
            sw.Flush();
            try
            {
                string text = sr.ReadLine();
                return int.Parse(text);
            }
            catch (Exception)
            {
                return -1;
            }

        }

        private string[] AskCredentials(StreamReader sr, StreamWriter sw)
        {
            sw.WriteLine("Tell me your email");
            sw.Flush();
            string[] words = new string[2];
            try
            {
                words[0] = sr.ReadLine();
                sw.WriteLine("Tell me your password");
                sw.Flush();
                words[1] = sr.ReadLine();
                return words;
            }
            catch
            {
                return null;
            }
        }

        private  bool FirstApproach(ref StreamReader sr, ref StreamWriter sw, ref bool closed)
        {
            sw.WriteLine("Welcome, do you want to sign up or sign in? Type 'up' to sign up, type 'in' to sing in, type bye to leave");
            sw.Flush();
            string text = null;
            do
            {
                text = sr.ReadLine();
                switch (text)
                {
                    case (null):
                        {
                            sr.Close();
                            sw.Close();
                            closed = true;
                            return false;
                        }
                    case ("up"):
                        {
                            return true;
                        }
                    case ("bye"):
                        {
                            sr.Close();
                            sw.Close();
                            closed = true;
                            return false;
                        }
                    case ("in"):
                        {
                            return false;
                        }
                    default:
                        {
                            sw.WriteLine("Type a correct input");
                            sw.Flush();
                            break;
                        }
                }
            }
            while (!text.Equals("up") && !text.Equals("in"));
            return true;
        }
        private void CloseUser()
        {
            sr.Close();
            sw.Close();
            ns.Close();
            clientSocket.Close();
            Server.getServerObject().getUsers().Remove(user);
            Server.getServerObject().GetSocketList().Remove(clientSocket);
            Server.getServerObject().BroadCast -= ms.SendMessage;
            Thread.CurrentThread.Abort();
        }
        public void Conversation()
        {
            bool hasClientBid = false;

            while (true)
            {

                string userText =" ";
                try
                {
                    userText = this.getUserText(sr);
                }
                catch (Exception)
                {
                    this.CloseUser();
                }
                if (userText == null)
                {
                    this.CloseUser();
                    
                }
                if (userText.Equals("bye"))
                {
                    this.CloseUser();
                }
                int bid = this.getBid(user, userText);


                switch (bid)
                {
                    case -1:
                        sw.WriteLine("Wrong Syntax");
                        sw.Flush();
                        hasClientBid = false;
                        break;
                    case -2:
                        sw.WriteLine("Balance is not enough");
                        sw.Flush();
                        hasClientBid = false;
                        break;
                    case -3:
                        this.CloseUser();
                        break;
                    case -4:
                        sw.WriteLine("bid is too low for the price of the item");
                        sw.Flush();
                        hasClientBid = false;
                        break;
                    default:
                        hasClientBid = true;
                        Server.getServerObject().BroadCastBid(bid, user);
                        Server.getServerObject().getGoodList().First().setLastBidder(user);
                        Server.getServerObject().getGoodList().First().setLastSocket(clientSocket);
                        Server.getServerObject().getGoodList().First().setPrice(bid);
                        Server.getServerObject().SetLastSocket(clientSocket);
                        break;
                }
                if (hasClientBid)
                {
                    Server.getServerObject().ResetTimer();   
                }
            }
        }

        private string getUserText(StreamReader sr)
        {
            string text = "";
            try
            {
                text = sr.ReadLine();
                return text;
            }
            catch (Exception)
            {
                return null;
            }
        }


        private int getBid(User u, string text)
        {

            string[] words = null;
            try
            {
                words = text.Split(' ');
            }
            catch (Exception)
            {
                return -3;
            }

            if (words.Length != 2 || !words[0].ToLower().Equals("bid"))
            {
                return -1;
            }
            try
            {
                int bid = int.Parse(words[1]);

                if (u.getBalance() < bid)
                {
                    return -2;
                }
                if (Server.getServerObject().getGoodList().First().getPrice() >= bid)
                {
                    return -4;
                }
                return bid;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        
    }
}
