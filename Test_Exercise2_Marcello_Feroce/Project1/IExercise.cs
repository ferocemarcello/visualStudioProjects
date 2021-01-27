using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public interface IExercise
    {
        DateTime StartTimeStamp { get; set; }
        int TotalMeasurementPoints { get; set; }
        void AddMeasurementPoint(Point point);
        double ElapsedTime();
        double TotalDistance();
        void EndExercise();
        double AverageSpeed();
    }
}
