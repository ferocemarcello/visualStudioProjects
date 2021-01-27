using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWriteReadFileDll;
using ClassLibrary1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string s = Class1.TryReturnText();
            Assert.IsTrue(Class1.TryReturnText()=="prova");
        }
    }
}
