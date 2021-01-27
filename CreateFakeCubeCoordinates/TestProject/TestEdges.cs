using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramProject;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class TestEdges
    {
        [TestMethod]
        public void TestEqualsEdges()
        {
            string path = @"C:\Users\feroc\Downloads\simpletriangles.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            List<Edge> edges = new List<Edge>();
            List<Triangle> triangles = new List<Triangle>();
            foreach (string line in lines)
            {
                //edges.Add(GetFirstEdgeFromLine(line));
                //edges.Add(GetSecondEdgeFromLine(line));
                triangles.Add(GetTriangleFromLine(line));
            }
            /*for(int x = 0; x < lines.Length; x++)
            {
                if(GetTriangleFromLine(lines[x]).TriangleEquals(new Triangle(new _3Dpoint(0,0,0),new _3Dpoint(0,117,0),new _3Dpoint(139, 0, 0))))
                {
                    Console.WriteLine(x + 1);
                }
            }*/
            foreach(Triangle t in triangles)
            {
                List<Triangle> fia = triangles.FindAll(item => item.TriangleEquals(t));
                if (triangles.FindAll(item => item.TriangleEquals(t)).Count != 1)
                {
                    Assert.Fail();
                }
            }
            Assert.IsTrue(true);
        }

        private Triangle GetTriangleFromLine(string line)
        {
            string[] coos = line.Split(' ');
            _3Dpoint p1 = new _3Dpoint(double.Parse(coos[0]), double.Parse(coos[1]), double.Parse(coos[2]));
            _3Dpoint p2 = new _3Dpoint(double.Parse(coos[3]), double.Parse(coos[4]), double.Parse(coos[5]));
            _3Dpoint p3 = new _3Dpoint(double.Parse(coos[6]), double.Parse(coos[7]), double.Parse(coos[8]));
            return new Triangle(p1, p2, p3);
        }

        private Edge GetFirstEdgeFromLine(string line)
        {
            string[] coos = line.Split(' ');
            //double d = double.Parse(coos[0]);
            _3Dpoint p1 = new _3Dpoint(double.Parse(coos[0]), double.Parse(coos[1]), double.Parse(coos[2]));
            _3Dpoint p2 = new _3Dpoint(double.Parse(coos[3]), double.Parse(coos[4]), double.Parse(coos[5]));

            return new Edge(p1, p2);
        }
        private Edge GetSecondEdgeFromLine(string line)
        {
            string[] coos = line.Split(' ');
            _3Dpoint p1 = new _3Dpoint(double.Parse(coos[3]), double.Parse(coos[4]), double.Parse(coos[5]));
            _3Dpoint p2 = new _3Dpoint(double.Parse(coos[6]), double.Parse(coos[7]), double.Parse(coos[8]));
            return new Edge(p1, p2);
        }
        [TestMethod]
        public void TestDistances()
        {
            _3Dpoint p1 = new _3Dpoint(3000, 2184, 0);
            _3Dpoint p2 = new _3Dpoint(2961, 2911, 3000);
            _3Dpoint p3 = new _3Dpoint(3000, 770, 100);
            double d12 = Math.Sqrt(Math.Pow(p1.GetX() - p2.GetX(), 2) + Math.Pow(p1.GetY() - p2.GetY(), 2) + Math.Pow(p1.GetZ() - p2.GetZ(), 2));
            double d13 = Math.Sqrt(Math.Pow(p1.GetX() - p3.GetX(), 2) + Math.Pow(p1.GetY() - p3.GetY(), 2) + Math.Pow(p1.GetZ() - p3.GetZ(), 2));
            double d23 = Math.Sqrt(Math.Pow(p2.GetX() - p3.GetX(), 2) + Math.Pow(p2.GetY() - p3.GetY(), 2) + Math.Pow(p2.GetZ() - p3.GetZ(), 2));
            Assert.IsTrue(d12< 3087.077906+0.000001|| d12> 3087.077906 - 0.000001);
            Assert.IsTrue(d13 < 1417.531657 + 0.000001 || d13> 1417.531657 - 0.000001);
            Assert.IsTrue( d23 < 3604.913591 + 0.000001 || d23 > 3604.913591 - 0.000001);
        }
        [TestMethod]
        public void TestNotEqualPoints()
        {
            string path = @"C:\Users\feroc\Downloads\cubeCartRand.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            List<_3Dpoint> points = new List<_3Dpoint>();
            foreach(string line in lines)
            {
                string[] coos = line.Split(' ');
                _3Dpoint p1 = new _3Dpoint(double.Parse(coos[0]), double.Parse(coos[1]), double.Parse(coos[2]));
                points.Add(p1);
            }
            
            foreach(_3Dpoint p in points)
            {
                List<_3Dpoint> fia = points.FindAll(item => item.PointEquals(p));
                if (fia.Count != 1) Assert.Fail();
            }
            Assert.IsTrue(true);
        }
    }
}
