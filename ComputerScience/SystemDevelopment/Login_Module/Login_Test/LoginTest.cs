using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Login_Component;

namespace Login_Test
{
    /// <summary>
    /// Summary description for LoginTest
    /// </summary>
    [TestClass]
    public class LoginTest
    {
        public static string connectionString = "Data Source = ealdb1.eal.local;" +
         "Initial Catalog=EAL5_DB;" +
         "Persist Security Info=true;" +
         "User ID=EAL5_USR;" +
         "Password=Huff05e05";

        [TestMethod]
        public void LoginTest_CreateAndLogin_void()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            l.LoginUser("ferocemarcello@gmail.com", "123456");
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoginTest_CreateAndLoginWrongPassword_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            
            try
            {
                l.LoginUser("ferocemarcello@gmail.com", "1233456");
                Assert.IsTrue(false);
            }
            catch (InvalidPasswordException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void LoginTest_CreateAndLoginWrongMail_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");

            try
            {
                l.LoginUser("ferocemarcello@gail.com", "123456");
                Assert.IsTrue(false);
            }
            catch (InvalidMailException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void LoginTestDb_CreateAndLogin_void()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper(connectionString);
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            l.LoginUser("ferocemarcello@gmail.com", "123456");
            //Deleting to avoid having an exception next time the test is executed
            l.DeleteUser("ferocemarcello@gmail.com", "123456");
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoginTestDb_CreateAndLoginWrongPassword_Exception()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper(connectionString);
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");

            try
            {
                l.LoginUser("ferocemarcello@gmail.com", "1233456");
                Assert.IsTrue(false);
            }
            catch (InvalidPasswordException)
            {
                //Deleting to avoid having an exception next time the test is executed
                l.DeleteUser("ferocemarcello@gmail.com", "123456");
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void LoginTestDb_CreateAndLoginWrongMail_Exception()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper(connectionString);
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");

            try
            {
                l.LoginUser("ferocemarcello@gail.com", "123456");
                Assert.IsTrue(false);
            }
            catch (InvalidMailException)
            {

                //Deleting to avoid having an exception ext time the test is executed
                l.DeleteUser("ferocemarcello@gmail.com", "123456");
                Assert.IsTrue(true);
            }
        }
    }
}
