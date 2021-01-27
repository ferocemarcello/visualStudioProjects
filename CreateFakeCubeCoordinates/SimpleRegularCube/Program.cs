using ProgramProject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRegularCube
{
    public class Program
    {
        public static void Main()
        {
            int x = 0, y = 0, z = 0;
            List<string> lines = new List<string>();
            LinkedList<string> xyFront = new LinkedList<string>();
            LinkedList<string> yzFront = new LinkedList<string>();
            LinkedList<string> xzFront = new LinkedList<string>();
            LinkedList<string> xyBack = new LinkedList<string>();
            LinkedList<string> yzBack = new LinkedList<string>();
            LinkedList<string> xzBack = new LinkedList<string>();
            LinkedList<_3Dpoint> points = new LinkedList<_3Dpoint>();
            double xCord, yCord, zCord;
            //xyfront
            for (y = 0; y < 3000; y = y+1000)
            {
                for (x = 0; x < 3000; x=x+1000)
                {
                    xCord = (double)x; yCord = (double)y;
                    points.AddLast(new _3Dpoint(xCord, yCord, 0.0));
                    xyFront.AddLast(xCord.ToString(CultureInfo.InvariantCulture) + " " + yCord.ToString(CultureInfo.InvariantCulture) + " " + "0.0");
                }
            }
            //xyback
            for (y = 0; y < 3000; y = y+1000)
            {
                for (x = 0; x < 3000; x =x+1000)
                {
                    xCord = (double)x; yCord = (double)y;
                    points.AddLast(new _3Dpoint(xCord, yCord, 3000.0));
                    xyBack.AddLast(xCord.ToString(CultureInfo.InvariantCulture) + " " + yCord.ToString(CultureInfo.InvariantCulture) + " " + "3000.0");
                }
            }
            //yzfront
            for (z = 0; z < 3000; z =z+1000)
            {
                for (y = 0; y < 3000; y=y+1000)
                {
                    yCord = (double)y; zCord = (double)z;
                    points.AddLast(new _3Dpoint(3000.0, yCord, zCord));
                    yzFront.AddLast("3000.0 " + yCord.ToString(CultureInfo.InvariantCulture) + " " + zCord.ToString(CultureInfo.InvariantCulture));
                }
            }
            //yzback
            for (z = 1000; z < 3000; z=z+1000)
            {
                for (y = 1000; y < 3000; y=y+1000)
                {
                    yCord = (double)y; zCord = (double)z;
                    points.AddLast(new _3Dpoint(0.0, yCord, zCord));
                    yzBack.AddLast("0.0 " + yCord.ToString(CultureInfo.InvariantCulture) + " " + zCord.ToString(CultureInfo.InvariantCulture));
                }
            }
            //xzfront
            for (z = 0; z < 3000; z=z+1000)
            {
                for (x = 0; x < 3000; x=x+1000)
                {
                    xCord = (double)x; zCord = (double)z;
                    points.AddLast(new _3Dpoint(xCord, 3000.0, zCord));
                    xzFront.AddLast(xCord.ToString(CultureInfo.InvariantCulture) + " 3000.0 " + zCord.ToString(CultureInfo.InvariantCulture));
                }
            }
            //xzback
            for (z = 1000; z < 3000; z=z+1000)
            {
                for (x = 1000; x < 3000; x=x+1000)
                {
                    xCord = (double)x; zCord = (double)z;
                    points.AddLast(new _3Dpoint(xCord, 0.0, zCord));
                    xzBack.AddLast(xCord.ToString(CultureInfo.InvariantCulture) + " 0.0 " + zCord.ToString(CultureInfo.InvariantCulture));
                }
            }
            lines = ((xyFront.Union(xyBack)).Union(yzFront.Union(yzBack)).Union(xzFront.Union(xzBack))).ToList();
            System.IO.File.WriteAllLines(@"C:\Users\feroc\Downloads\simpleCubeCart.txt", lines.ToArray());
            ProgramProject.Program.WriteTriangles(points, @"C:\Users\feroc\Downloads\simpletriangles.txt");
        }
    }
}
