using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Point
    {
        public DateTime TimeStamp { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double X, double Y, DateTime TimeStamp)
        {
            this.X= X;
            this.Y = Y;
            this.TimeStamp = TimeStamp;
        }
    }
}
