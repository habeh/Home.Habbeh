using Home.Habbeh.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Home.Habbeh.Entity;

namespace Home.Habbeh.DataAccess.Test
{


    /// <summary>
    ///This is a test class for ContactTest and is intended
    ///to contain all ContactTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContactTest
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
            Contact target = new Contact();
            TbContact contact = new TbContact() { Description = "TEST", UserId = 27, RegisterDate = DateTime.Now, Status = "1" };
            try
            {
                target.Create(contact);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
