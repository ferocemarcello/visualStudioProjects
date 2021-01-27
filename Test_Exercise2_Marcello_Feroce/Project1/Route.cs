using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Route
    {
        public DateTime StartTimeStamp { get; set; }
        public int TotalMeasurementPoints { get; set; }
        private LinkedList<Point> points;
        private delegate double CalcRouteField(string field);
        public Route()
        {
            this.StartTimeStamp = new DateTime(1900, 1, 1);
            this.points = new LinkedList<Point>();
        }
        private double Loop(string field)
        {
            if (TotalMeasurementPoints < 2) return 0.0;
            else
            {
                LinkedList<Point>.Enumerator en = points.GetEnumerator();
                en.MoveNext();
                Point previous = en.Current;
                double tot = 0;
                while (en.MoveNext())
                {                   
                    tot += (field=="distance")?Helper.CalcDistance(previous, en.Current): Helper.CalcTimeSpan(previous,en.Current);
                    previous = en.Current;
                }
                return tot;
            }
        }
        public double TotalDistance()
        {
            return Loop("distance");
        }

        public double ElapsedTime()
        {
            return Loop("time");
        }

        public double AverageSpeed()
        {
            if (TotalMeasurementPoints < 2) return 0.0;
            else return (TotalDistance() / ElapsedTime());
            
        }

        public void AddMeasurementPoint(Point p)
        {
            if ((p.X != 0 && p.Y != 0)&&((points.Count == 0)|| p.TimeStamp > points.Last.Value.TimeStamp))
            {
                    if (TotalMeasurementPoints == 0) StartTimeStamp = p.TimeStamp;
                this.points.AddLast(p);
                TotalMeasurementPoints++;
            }
            if (p.X != 0 && p.Y != 0&& (points.Count != 0)&& p.TimeStamp < points.Last.Value.TimeStamp)
            {
                Point rightPoint;
                rightPoint = points.Where(points => points.TimeStamp < p.TimeStamp).Last();
                LinkedListNode<Point> rightNode;
                rightNode = points.Find(rightPoint);
                points.AddAfter(rightNode, p);
                TotalMeasurementPoints++;
            }


        }
    }
}
