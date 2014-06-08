using Home.Habbeh.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Home.Habbeh.Entity;
using System.Collections.Generic;

namespace Home.Habbeh.Business.Test
{

    /// <summary>
    ///This is a test class for UserTest and is intended
    ///to contain all UserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserTest
    {
        private TestContext testContextInstance;
        private TbUser expected;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {

        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            expected = new TbUser() { UserName = "test", Email = "test@test.ir", Password = "test" };
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            expected = null;
        }
        //
        #endregion

        [TestMethod()]
        public void RegisterTest()
        {
            try
            {
                expected.Email = "karim.medusa@gmail.com";
                expected.UserName = "medusa";
                expected.Password = "123";
                User.Register(expected);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        [TestMethod()]
        public void SendForgiveInformationTest()
        {
            User.SendForgiveInformation(expected.Email);
        }

        [TestMethod()]
        public void LoginTest()
        {
            string username = "test";
            string password = "test";
            TbUser actual;
            actual = User.Login(username, password);
            Assert.IsNotNull(actual);
            Assert.AreEqual(username, actual.UserName);
        }

        [TestMethod()]
        public void GetProfileTest()
        {
            string username = "test";
            TbUser actual;
            actual = User.GetProfile(username);
            Assert.IsNotNull(actual);
            Assert.AreEqual(username, actual.UserName);
        }

        /// <summary>
        ///A test for Follow
        ///</summary>
        [TestMethod()]
        public void FollowTest()
        {
            int userId = 0; // TODO: Initialize to an appropriate value
            int followerId = 0; // TODO: Initialize to an appropriate value
            User.Follow(userId, followerId);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ChangeStatus
        ///</summary>
        [TestMethod()]
        public void ChangeStatusTest()
        {
            int userId = 0; // TODO: Initialize to an appropriate value
            int statusCode = 0; // TODO: Initialize to an appropriate value
            int changerUserId = 0; // TODO: Initialize to an appropriate value
            User.ChangeStatus(userId, statusCode, changerUserId);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void SearchTest()
        {
            string searchText = expected.UserName.Substring(0, 3);
            List<TbUser> actual = User.Search(searchText);
            Assert.IsTrue(actual.Count > 0);
        }
    }
}
