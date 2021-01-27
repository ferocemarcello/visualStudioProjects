using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject
{
    class Program
    { 
        public static void Main(string[] args)
        {
            Server s = new Server(11000);
        }
    }
}
