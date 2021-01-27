using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionPolarToCartesian
{
    class Program
    {
        static void Main(string[] args)
        {
            string file1Path = @"C:\Users\feroc\Downloads\Drawing5.fbx";
            string file2Path = @"C:\Users\feroc\Downloads\provafbx.txt";
            LinkedList<double> angles = PolarReader.ReadAngles(file1Path);
            LinkedList<double> lengths = PolarReader.ReadLengths(file1Path);
            Dictionary<double, double> polarCoordinates = new Dictionary<double, double>();
            Dictionary<double, double> cartesianCoordinates = new Dictionary<double, double>();
            LinkedList<double>.Enumerator en = angles.GetEnumerator();
            int x = 0;
            //Fill in the dictionary with the polar coordinates
            while (en.MoveNext())
            {
                polarCoordinates.Add(en.Current, lengths.ElementAt(x));
                x++;
            }
            //Fill in the dictionary with the cartesian coordinates(the polar converted ones)
            foreach (var c in polarCoordinates) cartesianCoordinates.Add(PolarToCartesianConverter.GetXFromPolars(c.Key, c.Value), PolarToCartesianConverter.GetYFromPolars(c.Key, c.Value));
            CartesianWriter.WriteCartesians(cartesianCoordinates,file2Path);
        }
    }
}
