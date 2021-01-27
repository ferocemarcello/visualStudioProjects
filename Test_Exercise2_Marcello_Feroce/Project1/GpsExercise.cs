using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class GpsExercise : IExercise
    {
        protected Route r;
        public GpsExercise()
        {
            r = new Route();
        }
        public DateTime StartTimeStamp
        {
            get
            {
                return r.StartTimeStamp;
            }

            set
            {
                r.StartTimeStamp = value;
            }
        }

        public int TotalMeasurementPoints
        {
            get
            {
                return r.TotalMeasurementPoints;
            }

            set
            {
                r.TotalMeasurementPoints = value;
            }
        }

        public void AddMeasurementPoint(Point point)
        {
            r.AddMeasurementPoint(point);
        }

        public double AverageSpeed()
        {
            return r.AverageSpeed();
        }

        public double ElapsedTime()
        {
            return r.ElapsedTime();
        }

        public void EndExercise()
        {
            
        }

        public double TotalDistance()
        {
            return r.TotalDistance();
        }
    }
}
