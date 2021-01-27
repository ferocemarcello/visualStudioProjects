
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {  
        public static void Main()
        {
            ServiceReference1.AuctionServiceClient cl = new ServiceReference1.AuctionServiceClient();
            ClientClass c = new ClientClass(cl);
            c.Run();
            Console.ReadLine();

        }
    }
}
