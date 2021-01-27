using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestExercise;

namespace UnitTestProject2
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void U_Factory_CreateIPerson_PersonTeacher()
        {
            IPerson testPerson = Factory.CreateIPerson("T", "Benny", 45, 100000);
            Assert.IsTrue(testPerson is Person);
            Assert.AreEqual(testPerson.GetRole(), "Teacher");
        }
        [TestMethod]
        public void U_Factory_CreateIPerson_PersonStudent()
        {
            IPerson testPerson = Factory.CreateIPerson("S", "My Name", 28, 5941);
            Assert.IsTrue(testPerson is Person);
            Assert.AreEqual(testPerson.GetRole(), "Student");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void U_Factory_UnknownRoleType_Exception()
        {
            IPerson testPerson = Factory.CreateIPerson("K", "My Name", 2, 0);
        }
    }
}
