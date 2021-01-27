using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Login_Component;
using Login_Component.Exceptions;

namespace Login_Test
{
    
    [TestClass]
    public class DeleteTest
    {

        public static string connectionString = "Data Source = ealdb1.eal.local;" +
                "Initial Catalog=EAL5_DB;" +
                "Persist Security Info=true;" +
                "User ID=EAL5_USR;" +
                "Password=Huff05e05";

        public DeleteTest()
        {

        }

        [TestMethod]
        public void DeleteUser_CreateAndDelete_void()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            l.DeleteUser("ferocemarcello@gmail.com", "123456");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DeleteUser_NotExisting_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            try
            {
                l.DeleteUser("ferocemarcello@gmail.com", "123456");
                Assert.IsTrue(false);
            }
            catch (NonExistingUserException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void DeleteUser_PasswordsNotMatching_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            try
            {
                l.DeleteUser("ferocemarcello@gmail.com", "123455");
                Assert.IsTrue(false);
            }
            catch (InvalidPasswordException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void DeleteUserDb_CreateAndDelete_void()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper(connectionString);
            Login l = new Login(ldm);
            l.CreateUser("shapournemati@gmail.com", "123456", "123456");
            l.DeleteUser("shapournemati@gmail.com", "123456");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DeleteUserDb_NotExisting_Exception()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper(connectionString);
            Login l = new Login(ldm);
            try
            {
                l.DeleteUser("ferocemarcello@gmail.comm", "123456");
                Assert.IsTrue(false);
            }
            catch (NonExistingUserException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void DeleteUserDb_PasswordsNotMatching_Exception()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper(connectionString);
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcellow@gmail.com", "123456", "123456");
            try
            {
                l.DeleteUser("ferocemarcellow@gmail.com", "123455");
                Assert.IsTrue(false);
            }
            catch (InvalidPasswordException)
            {
                Assert.IsTrue(true);
            }
            //Deleting to avoid having an exception ext time the test is executed
            l.DeleteUser("ferocemarcellow@gmail.com", "123456");
        }


    }
}
