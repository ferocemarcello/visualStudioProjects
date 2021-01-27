using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project1;

namespace UnitTestProject1
{
    [TestClass]
    public class Step03_RouteTest
    {
        [TestMethod]
        public void Exercise2_Route_NewRoute_InitSituation()
        {
            // Create a new empty route
            Route r = new Route();
            // We have not told it, so it replies
            Assert.AreEqual(new DateTime(1900, 1, 1), r.StartTimeStamp);
            // As we have not added any content
            Assert.AreEqual(0.0, r.TotalDistance());
            Assert.AreEqual(0.0, r.ElapsedTime());
            // As we have not added any content
            Assert.AreEqual(0, r.TotalMeasurementPoints);
            // We cannot calculate average speed without MeasurementPoints, so it returns 0.0 km/t
            Assert.AreEqual(0, r.AverageSpeed());
        }
        [TestMethod]
        public void Exercise2_Route_NewRoute_OnePointSituation()
        {
            // Create a new empty route
            Route r = new Route();
            // Our GPS starts collecting data:
            Point p = new Point(323.45, 438.34, new DateTime(2016, 8, 1, 19, 38, 10));
            r.AddMeasurementPoint(p);
            // It replies the TimeStamp of the first measurement point
            Assert.AreEqual(new DateTime(2016, 8, 1, 19, 38, 10), r.StartTimeStamp);
            // We cannot measure distance from one point, so it returns 0.0 km
            Assert.AreEqual(0.0, r.TotalDistance());
            Assert.AreEqual(0.0, r.ElapsedTime());
            // It has one point
            Assert.AreEqual(1, r.TotalMeasurementPoints);
            // We cannot calculate average speed from one point, so it returns 0.0 km/t
            Assert.AreEqual(0, r.AverageSpeed());
        }
        [TestMethod]
        public void Exercise2_Route_NewRoute_TwoPointsSituation()
        {
            // Create a new empty route
            Route r = new Route();
            // Our GPS starts collecting data:
            r.AddMeasurementPoint(new Point(323.45, 438.34, new DateTime(2016, 8, 1, 19, 38, 10)));
            r.AddMeasurementPoint(new Point(323.87, 439.01, new DateTime(2016, 8, 1, 19, 42, 21)));
            // It replies the TimeStamp of the first measurement point
            Assert.AreEqual(new DateTime(2016, 8, 1, 19, 38, 10), r.StartTimeStamp);
            // With two points, it can calculate a distance
            Assert.AreEqual(0.79, r.TotalDistance(), 0.01);
            Assert.AreEqual(0.07, r.ElapsedTime(), 0.01);
            // It has two points
            Assert.AreEqual(2, r.TotalMeasurementPoints);
            // With two points, it can calculate a average speed
            Assert.AreEqual(11.34, r.AverageSpeed(), 0.01);
        }
        [TestMethod]
        public void Exercise2_Route_NewRoute_SeveralPointsSituation()
        {
            // Create a new empty route
            Route r = new Route();
            // Our GPS starts collecting data:
            r.AddMeasurementPoint(new Point(323.45, 438.34, new DateTime(2016, 8, 1, 19, 38, 10)));
            r.AddMeasurementPoint(new Point(323.87, 439.01, new DateTime(2016, 8, 1, 19, 42, 21)));
            r.AddMeasurementPoint(new Point(324.17, 439.21, new DateTime(2016, 8, 1, 19, 43, 43)));
            r.AddMeasurementPoint(new Point(323.67, 440.03, new DateTime(2016, 8, 1, 19, 48, 32)));
            r.AddMeasurementPoint(new Point(323.61, 439.83, new DateTime(2016, 8, 1, 19, 49, 42)));
            r.AddMeasurementPoint(new Point(323.45, 438.34, new DateTime(2016, 8, 1, 19, 57, 15)));
            // It replies the TimeStamp of the first measurement point
            Assert.AreEqual(new DateTime(2016, 8, 1, 19, 38, 10), r.StartTimeStamp);
            // With two points, it can calculate a distance
            Assert.AreEqual(3.82, r.TotalDistance(), 0.01);
            Assert.AreEqual(0.32, r.ElapsedTime(), 0.01);
            // It has two points
            Assert.AreEqual(6, r.TotalMeasurementPoints);
            // With at least two points, it can calculate a average speed
            Assert.AreEqual(12.00, r.AverageSpeed(), 0.01);
        }
        [TestMethod]
        public void Exercise2_Route_NewRoute_BadGpsPointSituation()
        {
            // Create a new empty route
            Route r = new Route();
            // Our GPS starts collecting data:
            r.AddMeasurementPoint(new Point(323.45, 438.34, new DateTime(2016, 8, 1, 19, 38, 10)));
            r.AddMeasurementPoint(new Point(323.87, 439.01, new DateTime(2016, 8, 1, 19, 42, 21)));
            // Bad GPS point
            r.AddMeasurementPoint(new Point(0, 0, new DateTime(2016, 8, 1, 19, 43, 43)));
            r.AddMeasurementPoint(new Point(323.67, 440.03, new DateTime(2016, 8, 1, 19, 48, 32)));
            r.AddMeasurementPoint(new Point(323.61, 439.83, new DateTime(2016, 8, 1, 19, 49, 42)));
            r.AddMeasurementPoint(new Point(323.45, 438.34, new DateTime(2016, 8, 1, 19, 57, 15)));
            // It replies the TimeStamp of the first measurement point
            Assert.AreEqual(new DateTime(2016, 8, 1, 19, 38, 10), r.StartTimeStamp);
            // Leaving out the faulty point does make the route a bit shorter
            Assert.AreEqual(3.54, r.TotalDistance(), 0.01);
            Assert.AreEqual(0.32, r.ElapsedTime(), 0.01);
            // It has a point less
            Assert.AreEqual(5, r.TotalMeasurementPoints);
            // And therefore miscalculates speed
            Assert.AreEqual(11.12, r.AverageSpeed(), 0.01);
        }
        [TestMethod]
        public void Exercise2_Route_NewRoute_DelayedMeasurementSituation()
        {
            // Create a new empty route
            Route r = new Route();
            // Our GPS starts collecting data:
            r.AddMeasurementPoint(new Point(323.45, 438.34, new DateTime(2016, 8, 1, 19, 38, 10)));
            r.AddMeasurementPoint(new Point(324.17, 439.21, new DateTime(2016, 8, 1, 19, 43, 43)));
            r.AddMeasurementPoint(new Point(323.67, 440.03, new DateTime(2016, 8, 1, 19, 48, 32)));
            r.AddMeasurementPoint(new Point(323.61, 439.83, new DateTime(2016, 8, 1, 19, 49, 42)));
            // This measurement comes a tad late
            r.AddMeasurementPoint(new Point(323.87, 439.01, new DateTime(2016, 8, 1, 19, 42, 21)));
            r.AddMeasurementPoint(new Point(323.45, 438.34, new DateTime(2016, 8, 1, 19, 57, 15)));
            // It replies the TimeStamp of the first measurement point
            Assert.AreEqual(new DateTime(2016, 8, 1, 19, 38, 10), r.StartTimeStamp);
            // With two points, it can calculate a distance
            Assert.AreEqual(3.82, r.TotalDistance(), 0.01);
            Assert.AreEqual(0.32, r.ElapsedTime(), 0.01);
            // It has two points
            Assert.AreEqual(6, r.TotalMeasurementPoints);
            // With at least two points, it can calculate a average speed
            Assert.AreEqual(12.00, r.AverageSpeed(), 0.01);
        }

    }
}
