using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuctionHouseProject;

namespace Test
{
    [TestClass]
    public class LoginTest
    {
        private void TryCreateTable()
        {
            try
            {
                CreateUserTest.dm.CreateTable("AuctionHouseProjectLetterB");
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void DifferentPassword_Exception()
        {
            TryCreateTable();
            bool caught = true;
            User us = new User("ferocemarcello@gmail.com", "A3a_1fegsefw", 100000);
            CreateUserTest.inv.CreateUser(us);
            User us2 = new User("ferocemarcello@gmail.com", "A3a_1wfwWRGef", 100000);
            
            try
            {
                CreateUserTest.inv.LoginUser(us2.getEmail(), us2.getPassword());
                caught = false;
            }
            catch (DifferentPasswordException)
            {
                caught = true;
            }
            Assert.IsTrue(caught);
        }
        [TestMethod]
        public void NotFoundMail_Exception()
        {
            TryCreateTable();
            bool caught = true;
            User us = new User("ferocemarcello@gmail.com", "A3a_1fegsefw", 100000);
            CreateUserTest.inv.CreateUser(us);
            User us2 = new User("ferocemarcello2@gmail.com", "A3a_1fegsefw", 100000);

            try
            {
                CreateUserTest.inv.LoginUser(us2.getEmail(), us2.getPassword());
                caught = false;
            }
            catch (InvalidMailException)
            {
                caught = true;
            }
            Assert.IsTrue(caught);
        }
        

    }
}
