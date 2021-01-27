using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramProject
{
    class Program
    {
        private static Object thisLock = new Object();
        public static void Main(string[] args)
        {
            LinkedList<Thread> threadList = new LinkedList<Thread>();
            for(int i = 0; i < 20; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(myMethod));
                t.Name = i.ToString();
                threadList.AddLast(t);
            }
            foreach(Thread th in threadList)
            {
                th.Start(int.Parse(th.Name));
            }
            Console.ReadLine();
        }
        private static void myMethod(object threadIndex)
        {
            int threadIndexInt = (int)threadIndex;
            var waitHandle = new AutoResetEvent(false);
            if(threadIndexInt!=6) waitHandle.WaitOne();
                Console.WriteLine("Thread " + threadIndexInt.ToString() + " running");
                Thread.Sleep(5000);
            waitHandle.Set();
            Console.WriteLine("Thread " + threadIndexInt.ToString() + " running again");
        }
    }
}
