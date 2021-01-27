using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CircleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Circle" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Circle.svc or Circle.svc.cs at the Solution Explorer and start debugging.
    public class Circle : ICircle
    {
        public void DoWork()
        {
        }
        public double CalcDiameter(double radius)
        {
            return radius * 2;
        }
        public double CalcCircumference(double radius)
        {
            return 2 * radius * Math.PI;
        }
    }
}
