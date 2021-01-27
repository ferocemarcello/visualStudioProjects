using AuctionHouseProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace AuctionHouseProject
{
    public class Server
    {
        private int port = 11000;
        private IPAddress ip = IPAddress.Parse("185.19.132.82");
        private List<User> users;
        private List<Item> goodList;
        private List<Socket> socketList;
        private System.Timers.Timer timer1 = new System.Timers.Timer();
        private System.Timers.Timer timer2 = new System.Timers.Timer();
        private System.Timers.Timer timer3 = new System.Timers.Timer();
        private Socket lastSocket;
        private bool hasSomeoneBid;
        private bool hasSecondTimerStarted;
        private bool hasThirdTimerStarted;
        public delegate void useString(string text);
        public event useString BroadCast;
        private MsSqlDataMapper ldm = new MsSqlDataMapper("Data Source = ealdb1.eal.local;Initial Catalog=EAL5_DB;Persist Security Info=true;User ID=EAL5_USR;Password=Huff05e05");
        private Invoker inv;
        private static Server serverObject = new Server();

        public static Server getServerObject()
        {
            return Server.serverObject;
        }

        public List<Socket> GetSocketList()
        {
            return this.socketList;
        }

        public Socket GetLastSocket()
        {
            return this.lastSocket;
        }

        public void SetLastSocket(Socket lastSocket)
        {
            this.lastSocket = lastSocket;
        }

        public void checkUser(Socket clientSocket, Server s)
        {
            ClientHandler ch = new ClientHandler(clientSocket);
            ch.CheckUser();
        }

        private Server()
        {   
            inv = new Invoker(ldm);
            InitTimers();

            this.goodList = new List<Item>();
            this.users = new List<User>();
            this.socketList = new List<Socket>();
            this.goodList.Add(new Item("bike", 300));
            this.goodList.Add(new Item("table", 200));
            /*this.goodList.Add(new Item("lamp", 20));
            this.goodList.Add(new Item("chair", 30));*/
            
            Console.WriteLine("in database now\n\n");
            foreach (User us in this.ldm.ReadAllUsers())
            {
                Console.WriteLine(us.ToStringCustom());
            }
            Console.Write("\n\n");
        }

        private void InitTimers()
        {
            timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent1);
            timer2.Elapsed += new ElapsedEventHandler(OnTimedEvent2);
            timer3.Elapsed += new ElapsedEventHandler(OnTimedEvent3);
            timer1.Interval = 10000;
            timer2.Interval = 5000;
            timer3.Interval = 3000;
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
        }

        public Invoker getInvoker()
        {
            return this.inv;
        }
        public void setInvoker(Invoker inv)
        {
            this.inv = inv;
        }
        public MsSqlDataMapper getMsSqlDataMapper()
        {
            return this.ldm;
        }
        public void setMsSqlDataMapper(MsSqlDataMapper dm)
        {
            this.ldm = dm;
        }
        
        private void OnTimedEvent3(object sender, ElapsedEventArgs e)
        {
            this.timer3.Enabled = false;
            this.hasThirdTimerStarted = true;
            this.BroadCastMessage("Third. The item " + this.goodList.First().getName() + " has been sold to " + this.goodList.First().getLastBidder().getEmail()+", IP-PORT:"+ this.goodList.First().getLastSocket().RemoteEndPoint + " for a price of " + this.goodList.First().getPrice());
            this.DecreaseUserBalance(this.goodList.First().getPrice(), this.goodList.First().getLastBidder());
            this.goodList.RemoveAt(0);
            if (this.goodList.Count == 0)
            {
                this.BroadCast("Items are over. You are going to be disconnected");
                Thread.Sleep(10000);
                foreach(Socket s  in this.socketList)
                {
                    s.Shutdown(SocketShutdown.Both);
                    s.Close();
                }
                AuctionHouse.isAuctionOver = true;
                Environment.Exit(0);
            }
            else
            {
                this.SellNextItem();
            }
            
        }

        private void OnTimedEvent2(object sender, ElapsedEventArgs e)
        {
            this.timer2.Enabled = false;
            this.hasSecondTimerStarted = true;
            this.BroadCastMessage("Second");
            timer3.Enabled = true;
            while (!hasThirdTimerStarted)
            {
                if (this.hasSomeoneBid)
                {
                    timer3.Enabled = false;
                    Thread.CurrentThread.Abort();
                }
            }
        }

        private void OnTimedEvent1(object sender, ElapsedEventArgs e)
        {
            this.timer1.Enabled = false;
            Thread t = new Thread(new ThreadStart(() => this.TimeOverMethod()));
            t.Start();
        }

        private void TimeOverMethod()
        {
            this.hasSomeoneBid = false;
            this.BroadCastMessage("First");
            timer2.Enabled = true;
            while (!hasSecondTimerStarted)
            {
                if (this.hasSomeoneBid)
                {
                    timer2.Enabled = false;
                    Thread.CurrentThread.Abort();
                }
            }
        }

        private void SellNextItem()
        {
            if (this.goodList.Count == 0)
            {
                AuctionHouse.isAuctionOver = true;
            }
            this.BroadCastMessage("OK, next good is a " + this.goodList.First().getName() + " for a starting price of " + this.goodList.First().getPrice() + " dkk");
            for (int i = 0; i < this.socketList.Count; i++)
            {
                NetworkStream n = new NetworkStream(this.socketList.ElementAt(i));
                StreamWriter sw = new StreamWriter(n);
                User u = this.users.ElementAt(i);
                sw.WriteLine("user " + u.getEmail() + " you have a balance of " + u.getBalance() + " dkk");
                sw.Flush();
                sw.Close();
                n.Close();
            }
        }

        private void BroadCastMessage(string v)
        {
            this.BroadCast?.Invoke(v);
        }

        public IPAddress getServerIp()
        {
            return this.ip;
        }
        public int getServerPort()
        {
            return this.port;
        }

        public List<Item> getGoodList()
        {
            return this.goodList;
        }
        public List<User> getUsers()
        {
            return this.users;
        }
        
        public void Connection(User u, Socket clientSocket)
        {
            Console.WriteLine("in session now\n\n");
            foreach (User us in this.users)
            {
                Console.WriteLine(us.ToStringCustom());
            }
            ClientHandler ch = new ClientHandler(clientSocket,u);
            this.BroadCast += ch.GetMs().SendMessage;
            this.socketList.Add(clientSocket);

            ch.WelcomeMessage();
            ch.Conversation();
        }

        private void DecreaseUserBalance(int bid, User u)
        {
            int newBalance = u.getBalance() - bid;
            u.setBallance(newBalance);
            this.inv.UpdateBalance(u.getEmail(), newBalance);
        }

        public void BroadCastBid(int bid, User u)//next we can do with delegate
        {
            string text = ("Clients, " + u.getEmail() + " did a bid of " + bid + " dkk");
            this.BroadCast(text);
        }      

        public int getUserBalance(string email)
        {   
            User u = this.ldm.Read(email);
            int balance = u.getBalance();
            return balance;
        }

        public bool CkeckMatchingMailAndPassword(string email, string password)
        {
            User u = ldm.Read(email);
            if (u!=null&&u.getPassword().Equals(Helper.GetEncryptedPassword(password))) return true;
            return false;
        }

        public void addUser(User user)
        {
            this.users.Add(user);
        }

        public void ResetTimer()
        {
            this.timer1.Enabled = false;
            this.timer1.Enabled = true;
            this.hasSomeoneBid = true;
        }
    }
}
