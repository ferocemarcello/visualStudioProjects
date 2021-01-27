using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Login_Component;
using Login_Component.Exceptions;

namespace Login_Test
{
    /// <summary>
    /// Summary description for ResetMailTest
    /// </summary>
    [TestClass]
    public class ResetMailTest
    {

        public static string connectionString = "Data Source = ealdb1.eal.local;" +
                "Initial Catalog=EAL5_DB;" +
                "Persist Security Info=true;" +
                "User ID=EAL5_USR;" +
                "Password=Huff05e05";

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        [TestMethod]
        public void ResetMail_CreateAndReset_void()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            l.ResetMail("ferocemarcello@gmail.com","ferocemarcello2@gmail.com");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ReseMail_NotExisting_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            try
            {
                l.ResetMail("ferocemarcell2o@gmail.com", "ferocemarcellrfw2o@gmail.com");
                Assert.IsTrue(false);
            }
            catch (NonExistingUserException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ResetMailDB_CreateAndReset_void()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper(connectionString);
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            l.ResetMail("ferocemarcello@gmail.com", "ferocemarcello2@gmail.com");
            l.DeleteUser("ferocemarcello2@gmail.com", "123456");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ReseMailDb_NotExisting_Exception()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper(connectionString);
            Login l = new Login(ldm);
            try
            {
                l.ResetMail("ferocemarcell2o@gmail.com", "ferocemarcellrfw2o@gmail.com");
                Assert.IsTrue(false);
            }
            catch (NonExistingUserException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
