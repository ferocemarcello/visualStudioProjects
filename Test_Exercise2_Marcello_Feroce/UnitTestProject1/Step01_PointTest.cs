using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project1;

namespace UnitTestProject1
{
    [TestClass]
    public class Step01_PointTest
    {
        [TestMethod]
        public void Exercise2_Point_Constructor_Void()
        {
            // Create two test points
            Point p1 = new Point(323.45, 438.34, new DateTime(2016, 8, 1, 19, 38, 10));
            Point p2 = new Point(323.87, 439.01, new DateTime(2016, 8, 1, 19, 42, 31));
            // Test that the constructor actually sets the properties
            Assert.AreEqual(323.45, p1.X, 0.001);
            Assert.AreEqual(438.34, p1.Y, 0.001);
            Assert.AreEqual(new DateTime(2016, 8, 1, 19, 38, 10), p1.TimeStamp);
            // Test that the property don't just return the same number all the time
            Assert.AreNotEqual(323.45, p2.X, 0.001);
            Assert.AreNotEqual(438.34, p2.Y, 0.001);
            Assert.AreNotEqual(new DateTime(2016, 8, 1, 19, 38, 10), p2.TimeStamp);
        }
    }
}
