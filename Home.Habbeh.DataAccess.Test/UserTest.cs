using Home.Habbeh.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Home.Habbeh.Entity;
using System.Collections.Generic;

namespace Home.Habbeh.DataAccess.Test
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
        private User target;

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
        [ClassCleanup()]
        public static void MyClassCleanup()
        {

        }
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            target = new User();
            expected = new TbUser() { UserName = "test", Email = "test@test.ir", Password = "test" };
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            target.Dispose();
            expected = null;
        }
        //
        #endregion


        /// <summary>
        ///A test for Retrieve
        ///</summary>
        [TestMethod()]
        public void RetrieveTest()
        {
            try
            {
                TbUser actual = target.Retrieve(expected.UserName, expected.Password);
                Assert.IsNotNull(actual);
                Assert.AreEqual(expected.UserName, actual.UserName);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            try
            {
                expected.Status = "1";
                expected.RegisterDate = DateTime.Now;
                target.Create(expected);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for Retrieve
        ///</summary>
        [TestMethod()]
        public void RetrieveByUserNameTest()
        {
            try
            {
                TbUser actual = target.Retrieve(expected.UserName);
                Assert.IsNotNull(actual);
                Assert.AreEqual(expected.UserName, actual.UserName);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for RetrieveList
        ///</summary>
        [TestMethod()]
        public void RetrieveListTest()
        {
            try
            {
                string searchText = expected.UserName.Substring(0, 3);
                List<TbUser> actual;
                actual = target.RetrieveList(searchText);
                Assert.IsTrue(actual.Count > 0);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            try
            {
                int statusId = 2;
                target.Update(expected.UserName, statusId);
                TbUser actual = target.Retrieve(expected.UserName);
                Assert.IsNotNull(actual);
                Assert.AreEqual(statusId, actual.Status);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateByTbUserTest()
        {
            User target = new User(); // TODO: Initialize to an appropriate value
            TbUser user = null; // TODO: Initialize to an appropriate value
            target.Update(user);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RetrieveByEmail
        ///</summary>
        [TestMethod()]
        public void RetrieveByEmailTest()
        {
            User target = new User(); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            TbUser expected = null; // TODO: Initialize to an appropriate value
            TbUser actual;
            actual = target.RetrieveByEmail(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
