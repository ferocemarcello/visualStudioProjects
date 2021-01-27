using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleClientProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcCircleService.CircleClient circle;
            circle = new CalcCircleService.CircleClient();
            Console.WriteLine("Diameter: "+circle.CalcDiameter(5));
            Console.WriteLine("Circumference: " + circle.CalcCircumference(5));
            double mipi = Math.PI;
            int myint = 0;
            for (int i=0; i < 20; i++)
            {
                myint = (int)mipi;
                Console.Write(myint);
                if (i == 0) Console.Write(",");
                mipi = (mipi - myint) * 10;
            }
            //Console.WriteLine( Math.PI.ToString());
            Console.ReadLine();
        }
    }
}
