using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Login_Component;
using Login_Component.Exceptions;

namespace Login_Test
{
        [TestClass]
    public class ResetPasswordTest
    {
        public ResetPasswordTest()
        {
        }

        public static string connectionString = "Data Source = ealdb1.eal.local;" +
                "Initial Catalog=EAL5_DB;" +
                "Persist Security Info=true;" +
                "User ID=EAL5_USR;" +
                "Password=Huff05e05";

        [TestMethod]
        public void ResetPassword_CreateAndReset_void()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            l.ResetPassword("ferocemarcello@gmail.com", "123456","1234567","1234567");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ResetPassword_NotExisting_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            try
            {
                l.ResetPassword("ferocemarcello@gmail.com", "123456","1234567","1234567");
                Assert.IsTrue(false);
            }
            catch (NonExistingUserException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void ResetPassword_PasswordsNotMatching_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            try
            {
                l.ResetPassword("ferocemarcello@gmail.com", "123457", "1234567", "1234567");
                Assert.IsTrue(false);
            }
            catch (InvalidPasswordException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ResetPasswordDb_CreateAndReset_void()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper(connectionString);
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            l.ResetPassword("ferocemarcello@gmail.com", "123456", "1234567", "1234567");
            l.DeleteUser("ferocemarcello@gmail.com", "1234567");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ResetPasswordDb_NotExisting_Exception()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper(connectionString);
            Login l = new Login(ldm);
            try
            {
                l.ResetPassword("ferocemarcello@gmail.com", "123456", "1234567", "1234567");
                Assert.IsTrue(false);
            }
            catch (NonExistingUserException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ResetPasswordDb_PasswordsNotMatching_Exception()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper(connectionString);
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            try
            {
                l.ResetPassword("ferocemarcello@gmail.com", "123457", "1234567", "1234567");
                Assert.IsTrue(false);
            }
            catch (InvalidPasswordException)
            {
                l.DeleteUser("ferocemarcello@gmail.com", "123456");
                Assert.IsTrue(true);
            }
        }
    }
}
