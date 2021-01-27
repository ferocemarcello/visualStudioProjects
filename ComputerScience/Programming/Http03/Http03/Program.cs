using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Http03
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            //client.Headers.Add("Content-Type", "text/plain; charset=UTF-8");  // ekstra header info
            //client.Encoding = Encoding.UTF8;                                  // ekstra om encoding
            string Message = client.DownloadString(" http://webservicedemo.datamatiker-skolen.dk/RegneWcfService.svc/RESTjson/Add?a=5&b=8");
            Console.WriteLine("Message:" + Message + ":end of Message");
            Console.ReadLine();
        }
    }
}
