using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class ManuelExercise : GpsExercise,IExercise
    {

        public ManuelExercise(DateTime startDateTime, double X, double Y)
        {
            r.AddMeasurementPoint(new Point(0.1, 0.1, r.StartTimeStamp));
            this.AddMeasurementPoint(new Point(X, Y, startDateTime));
        }
        
    }
}
