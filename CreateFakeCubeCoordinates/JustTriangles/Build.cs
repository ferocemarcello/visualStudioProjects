using ProgramProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTriangles
{
    public class Build
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\feroc\Downloads\complanari.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            LinkedList<_3Dpoint> points = new LinkedList<_3Dpoint>();
            foreach (string line in lines)
            {
                string[] coos = line.Split(' ');
                _3Dpoint p1 = new _3Dpoint(double.Parse(coos[0]), double.Parse(coos[1]), double.Parse(coos[2]));
                points.AddLast(p1);
            }
            ProgramProject.Program.WriteTriangles(points, @"C:\Users\feroc\Downloads\triangolicomplanari.txt");
        }
    }
}
