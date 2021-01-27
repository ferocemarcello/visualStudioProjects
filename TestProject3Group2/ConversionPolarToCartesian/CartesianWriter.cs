using System;
using System.Collections.Generic;

namespace ConversionPolarToCartesian
{
    public class CartesianWriter
    {
        public static void WriteCartesians(Dictionary<double, double> cartesianCoordinates,string path)
        {
            List<string> lines = new List<string>();
            string[] x;string[] y;
            foreach (var p in cartesianCoordinates)
            {
                x =p.Key.ToString().Split(',');
                y = p.Value.ToString().Split(',');
                lines.Add(x[0] + "."+x[1]+" "+y[0]+"."+y[1]);
            }
            string[] coos = lines.ToArray();
            System.IO.File.WriteAllLines(path, lines);
        }
    }
}