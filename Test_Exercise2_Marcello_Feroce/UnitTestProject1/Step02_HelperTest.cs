using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project1;

namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class Step02_HelperTest
    {
        public Step02_HelperTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        Point p1, p2, p3, p4;
        [TestInitialize]
        public void SetupPoints()
        {
            p1 = new Point(10.0, 10.0, System.DateTime.Now);
            p2 = new Point(20.0, 20.0, System.DateTime.Now.AddMinutes(30));
            p3 = new Point(0.0, 10.0, System.DateTime.Now.AddHours(1));
            p4 = new Point(10.0, -10.0, System.DateTime.Now.AddHours(1).AddMinutes(30));
        }
        [TestMethod]
        public void Exercise2_Helper_CalcDistance_Double()
        {
            // Accordin to Pythagoras, the distance must be:
            // Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
            double dist12 = Helper.CalcDistance(p1, p2);
            double dist13 = Helper.CalcDistance(p1, p3);
            double dist14 = Helper.CalcDistance(p1, p4);
            double dist23 = Helper.CalcDistance(p2, p3);
            double dist24 = Helper.CalcDistance(p2, p4);
            double dist34 = Helper.CalcDistance(p3, p4);
            double dist43 = Helper.CalcDistance(p4, p3);
            // Test the calculation in the different scenarios
            // As we have calculated several combinations, we do not need AssertNotEqual
            Assert.AreEqual(14.14, dist12, 0.01);
            Assert.AreEqual(10.00, dist13, 0.01);
            Assert.AreEqual(20.00, dist14, 0.01);
            Assert.AreEqual(22.36, dist23, 0.01);
            Assert.AreEqual(31.62, dist24, 0.01);
            Assert.AreEqual(22.36, dist34, 0.01);
            Assert.AreEqual(22.36, dist43, 0.01);
        }
        [TestMethod]
        public void Exercise2_Helper_CalctimeDiff_Double()
        {
            // Calculation like this:
            // (p2.TimeStamp - p2.TimeStamp).TotalMilliseconds / (1000 * 60 * 60);
            double time12 = Helper.CalcTimeSpan(p1, p2);
            Assert.AreEqual(0.5, time12, 0.01);
        }
    }
}
