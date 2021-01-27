using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Helper
    {
        public static double CalcDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));

        }

        public static double CalcTimeSpan(Point p1, Point p2)
        {
            return (p2.TimeStamp - p1.TimeStamp).TotalMilliseconds / (1000 * 60 * 60);
        }
    }
}
