using Home.Habbeh.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Home.Habbeh.Entity;
using System.Collections.Generic;

namespace Home.Habbeh.DataAccess.Test
{


    /// <summary>
    ///This is a test class for MessageTest and is intended
    ///to contain all MessageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MessageTest
    {


        private TestContext testContextInstance;

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
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            Message target = new Message(); // TODO: Initialize to an appropriate value
            TbMessage msg = new TbMessage() { CategoryId = 1, Description = "تست", RegisterDate = DateTime.Now, UserId = 27 };
            try
            {
                target.Create(msg);
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
            Message target = new Message(); // TODO: Initialize to an appropriate value
            DateTime lastReadMessage = DateTime.Now;

            List<TbMessage> actual;
            try
            {
                actual = target.RetrieveList(lastReadMessage);
                Assert.IsTrue(actual.Count > 0);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
