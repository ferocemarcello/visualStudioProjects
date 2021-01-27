using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project1;

namespace UnitTestProject1
{
    [TestClass]
    public class Step04_ExerciseTest
    {
        [TestMethod]
        public void Exercise2_CreateExercise_NewRoute_InitSituation()
        {
            IExercise e = new GpsExercise();
            e.AddMeasurementPoint(new Point(323.45, 438.34, new DateTime(2016, 8, 1, 19, 38, 10)));
            e.AddMeasurementPoint(new Point(323.87, 439.01, new DateTime(2016, 8, 1, 19, 42, 21)));
            e.AddMeasurementPoint(new Point(324.17, 439.21, new DateTime(2016, 8, 1, 19, 43, 43)));
            e.AddMeasurementPoint(new Point(323.67, 440.03, new DateTime(2016, 8, 1, 19, 48, 32)));
            e.AddMeasurementPoint(new Point(323.61, 439.83, new DateTime(2016, 8, 1, 19, 49, 42)));
            e.AddMeasurementPoint(new Point(323.45, 438.34, new DateTime(2016, 8, 1, 19, 57, 15)));
            // It replies the TimeStamp of the first measurement point
            Assert.AreEqual(new DateTime(2016, 8, 1, 19, 38, 10), e.StartTimeStamp);
            // With two points, it can calculate a distance
            Assert.AreEqual(3.82, e.TotalDistance(), 0.01);
            Assert.AreEqual(0.32, e.ElapsedTime(), 0.01);
            // It has two points
            Assert.AreEqual(6, e.TotalMeasurementPoints);
            // With at least two points, it can calculate a average speed
            Assert.AreEqual(12.00, e.AverageSpeed(), 0.01);
            e.EndExercise();
        }
        [TestMethod]
        public void Exercise2_CreateExercise_NewRoute_OnePointSituation()
        {
            IExercise e1 = new ManuelExercise(new DateTime(2016, 8, 1, 19, 38, 10), 8.4, 0.66);
            IExercise e2 = new ManuelExercise(new DateTime(2016, 9, 1, 19, 38, 10), 21.1, 1.98);
            // It replies the TimeStamp of the first measurement point
            Assert.AreEqual(new DateTime(2016, 8, 1, 19, 38, 10), e1.StartTimeStamp);
            Assert.AreNotEqual(new DateTime(2016, 8, 1, 19, 38, 10), e2.StartTimeStamp);
            // Retrieve distance
            Assert.AreEqual(8.4, e1.TotalDistance(), 0.01);
            Assert.AreNotEqual(8.4, e2.ElapsedTime(), 0.01);
            // With at least two points, it can calculate a average speed
            Assert.AreEqual(12.73, e1.AverageSpeed(), 0.01);
            Assert.AreNotEqual(12.73, e2.AverageSpeed(), 0.01);
        }
    }
}
