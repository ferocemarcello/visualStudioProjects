using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Login_Component;
using Login_Component.Exceptions;

namespace Login_Test
{
    [TestClass]
    public class CreateUserTest
    {
        [TestMethod]
        public void CreateUser_AllInputOK_void()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void CreateUser_PasswordShort_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);
            
            try
            {
                l.CreateUser("ferocemarcello@gmail.com", "12356", "12356");
                Assert.IsTrue(false);
            }
            catch(ShortPasswordException)
            {
                Assert.IsTrue(true);
            }
            
        }
        [TestMethod]
        public void CreateUser_DifferentPassword_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);

            try
            {
                l.CreateUser("ferocemarcello@gmail.com", "123546", "123256");
                Assert.IsTrue(false);
            }
            catch (DifferentPasswordException)
            {
                Assert.IsTrue(true);
            }

        }
        [TestMethod]
        public void CreateUser_AlreadyExisting_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);

            try
            {
                l.CreateUser("ferocemarcello@gmail.com", "123456", "123456");
                l.CreateUser("ferocemarcello@gmail.com", "2234567", "2234567");
                Assert.IsTrue(false);
            }
            catch (AlreadyExistingUserException)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        public void CreateUser_EmailTooShort_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);

            try
            {
                l.CreateUser("fm", "123456", "123456");
                Assert.IsTrue(false);
            }
            catch (ShortEmailException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void CreateUser_EmailSyntaxError_Exception()
        {
            ILoginDataMapper ldm = new FakeDataMapper();
            Login l = new Login(ldm);

            try
            {
                l.CreateUser("ferocemarcellogmailpuntocom", "123456", "123456");
                Assert.IsTrue(false);
            }
            catch (EmailSyntaxWrongException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void CreateUserDb_AllInputOK_void()
        {
            ILoginDataMapper ldm = new MsSqlLoginDataMapper("Data Source = ealdb1.eal.local;"+
            "Initial Catalog=EAL5_DB;"+
            "Persist Security Info=true;"+
            "User ID=EAL5_USR;"+
            "Password=Huff05e05");
            Login l = new Login(ldm);
            l.CreateUser("provaprova@gmail.com", "1234567", "1234567");
            //Deleting to avoid having an exception ext time the test is executed
            l.DeleteUser("provaprova@gmail.com", "1234567");
            Assert.IsTrue(true);
        }

    }
}
