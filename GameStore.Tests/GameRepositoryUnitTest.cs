using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameStore.Domian.DataBaseProvider;

namespace GameStore.Tests
{
    /// <summary>
    /// Summary description for GameRepositoryUnitTest
    /// </summary>
    [TestClass]
    public class GameRepositoryUnitTest
    {
        GameStore.Domian.Concrete.GameRepository gameRepository; 
        public GameRepositoryUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //

            this.gameRepository = new Domian.Concrete.GameRepository();
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestConnectedToDB()
        {
            //
            // TODO: Add test logic here
            //
            Assert.IsNotNull(this.gameRepository.Games);
        }

        [TestMethod]
        public void TestCountItems()
        {
            //
            // TODO: Add test logic here
            //

            List<Game> games = new List<Game>(this.gameRepository.Games);
            Assert.AreEqual<Int32>(3, games.Count); 
        }
    }
}
