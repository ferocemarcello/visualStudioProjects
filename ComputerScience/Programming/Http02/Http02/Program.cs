using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Http02
{
    class Program
    {

        static void Main(string[] args)
        {
            TcpClient socket;
            //IPHostEntry host = Dns.GetHostEntry("webservicedemo.datamatiker-skolen.dk");
            NetworkStream ns;
            StreamWriter sw;
            StreamReader sr;

            socket = new TcpClient("webservicedemo.datamatiker-skolen.dk", 80);
            ns = socket.GetStream();
            sw = new StreamWriter(ns);
            sr = new StreamReader(ns);
            sw.WriteLine("GET http://webservicedemo.datamatiker-skolen.dk/RegneWcfService.svc/RESTjson/Add?a=0&b=1009000000 HTTP/1.1");
            sw.WriteLine("Host: webservicedemo.datamatiker - skolen.dk" + Environment.NewLine);
            sw.Flush();
            string text;
            //text = sr.ReadToEnd();
            text = ReceiveMessage(sr);
            Console.WriteLine(text);
            sr.Close();
            sw.Close();
            ns.Close();
            socket.Close();
            Console.ReadLine();
        }

        private static string ReceiveMessage(StreamReader sr)
        {
            int i = 1;
            char c;
            LinkedList<string> slist = new LinkedList<string>();
            LinkedList<char> s = new LinkedList<char>();
            string text = "";
            string[] arr = new string[1024];
            int n = 0;
            List<char> ca = new List<char>();
            while (i!=0)
            {
                    text = sr.ReadLine();
                    slist.AddLast(text);
                    
                    if (text.Contains("Length"))
                    {
                        arr = text.Split(' ');
                        n = int.Parse(arr[arr.Length - 1]);
                    }
                ca = text.ToCharArray().ToList();

                if (ca.Count==0)
                {
                    ca.Clear();
                    for (int x = 0; x < n; x++)
                    {
                        ca.Add((char)sr.Read());
                    }
                    i = 0;
                }
            }
            
            foreach (char a in ca)
            {
                text += a;
            }
            return text;
        }
    }
}
