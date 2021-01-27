using System;
using System.Collections.Generic;

namespace ConversionPolarToCartesian
{
    public class PolarReader
    {
        public static LinkedList<double> ReadAngles(string file1Path)
        {
            string[] lines = System.IO.File.ReadAllLines(file1Path);
            LinkedList<double> angles = new LinkedList<double>();
            foreach(var x in lines)
            {
                if (!x.Contains("#"))
                {
                    string[] splitted = x.Split(' ');
                    string angle = splitted[0].Split('.')[0] + "," + splitted[0].Split('.')[1];
                    angles.AddLast(double.Parse(angle));
                }
            }
            return angles;
        }

        public static LinkedList<double> ReadLengths(string file1Path)
        {
            string[] lines = System.IO.File.ReadAllLines(file1Path);
            LinkedList<double> lengths = new LinkedList<double>();
            foreach (var x in lines)
            {
                if (!x.Contains("#"))
                {
                    string[] splitted = x.Split(' ');
                    string angle = splitted[1].Split('.')[0] + "," + splitted[1].Split('.')[1];
                    lengths.AddLast(double.Parse(angle));
                }
            }
            return lengths;
        }
    }
}