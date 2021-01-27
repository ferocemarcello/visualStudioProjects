using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuctionHouseProject;
using System;

namespace Test
{
    [TestClass]
    public abstract class CreateUserTest
    {
        
        public static MsSqlDataMapper dm = new MsSqlDataMapper("Data Source = ealdb1.eal.local;Initial Catalog=EAL5_DB;Persist Security Info=true;User ID=EAL5_USR;Password=Huff05e05");
        public static Invoker inv = new Invoker(dm);

        private void TryCreateTable()
        {
            try
            {
                dm.CreateTable("AuctionHouseProjectLetterB");
            }
            catch(Exception)
            {
            }
        }
        [TestMethod]
        public void TestAllInputOK_void()
        {
            bool gone = true;
            TryCreateTable();
            try
            {
                User us = new User("ferocemarcello@gmail.com", "C_123456", 100000);
                inv.CreateUser(us);
            }
            catch(Exception)
            {
                gone = false;
            }
            Assert.IsTrue(gone);
        }
        [TestMethod]
        public void TestShortEmail_Exception()
        {
            TryCreateTable();
            bool caught = true;
            User us = new User("fer@", "C_123456", 100000);
            try
            {
                inv.CreateUser(us);
                caught = false;
            }
            catch (ShortEmailException)
            {
                caught = true;
            }
            Assert.IsTrue(caught);
        }
        [TestMethod]
        public void AlreadyExistingUser_Exception()
        {
            TryCreateTable();
            bool caught = true;
            User us = new User("ferocemarcello@gmail.com", "C_123456", 100000);
            inv.CreateUser(us);
            User us2 = new User("ferocemarcello@gmail.com", "C_123456", 100000);
            try
            {
                inv.CreateUser(us2);
                caught = false;
            }
            catch (AlreadyExistingUserException)
            {
                caught = true;
            }
            Assert.IsTrue(caught);
        }
        [TestMethod]
        public void EmailNotContainingAt_Exception()
        {
            TryCreateTable();
            bool caught = true;
            User us = new User("ferocemarcellogmail.com", "C_123456", 100000);
            try
            {
                inv.CreateUser(us);
                caught = false;
            }
            catch (EmailNotContainingAtException)
            {
                caught = true;
            }
            Assert.IsTrue(caught);
        }
        [TestMethod]
        public void NotContainingCapitalLetter_Exception()
        {
            TryCreateTable();
            bool caught = true;
            User us = new User("ferocemarcello@gmail.com", "_123456", 100000);
            try
            {
                inv.CreateUser(us);
                caught = false;
            }
            catch (NotContainingCapitalLetterException)
            {
                caught = true;
            }
            Assert.IsTrue(caught);
        }
        [TestMethod]
        public void NotContainingNumber_Exception()
        {
            TryCreateTable();
            bool caught = true;
            User us = new User("ferocemarcello@gmail.com", "A_sadfsd", 100000);
            try
            {
                inv.CreateUser(us);
                caught = false;
            }
            catch (NotContainingNumberException)
            {
                caught = true;
            }
            Assert.IsTrue(caught);
        }
        [TestMethod]
        public void NotContainingSpecialChar_Exception()
        {
            TryCreateTable();
            bool caught = true;
            User us = new User("ferocemarcello@gmail.com", "A3sadfsd", 100000);
            try
            {
                inv.CreateUser(us);
                caught = false;
            }
            catch (NotContainingSpecialCharException)
            {
                caught = true;
            }
            Assert.IsTrue(caught);
        }
        [TestMethod]
        public void ShortPassword_Exception()
        {
            TryCreateTable();
            bool caught = true;
            User us = new User("ferocemarcello@gmail.com", "A3a_1", 100000);
            try
            {
                inv.CreateUser(us);
                caught = false;
            }
            catch (ShortPasswordException)
            {
                caught = true;
            }
            Assert.IsTrue(caught);
        }


    }
}
