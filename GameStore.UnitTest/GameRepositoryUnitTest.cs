using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameStore.WUI.Models;
using GameStore.WUI.Models.Concrete;

namespace GameStore.UnitTest
{
    /// <summary>
    /// Summary description for GameRepositoryUnitTest
    /// </summary>
    [TestClass]
    public class GameRepositoryUnitTest
    {
        public GameRepositoryUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //

            this.gameRepository = new GameRepository();
            this.games = new List<Game>(this.gameRepository.Games);
        }

        private TestContext testContextInstance;
        private GameRepository gameRepository;
        private List <Game> games;

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
            Assert.IsNotNull(this.gameRepository.Games);
        }

        [TestMethod]
        public void TestAddedItemsToDB()
        {
            int gamesCount = games.Count;
            for (int i = 0; i < 3; i++)
            {
                this.games.Add(new TestingGame());
                Assert.AreEqual<Int32>(gamesCount + 1, games.Count);
                gamesCount = games.Count;
            }
        }


        public class TestingGame : Game
        {
            private static int index = 0;

            public TestingGame()
            {

                this.Name = "test name; " + GenerateNumber();
                this.Description = "test name; " + GenerateNumber();
                this.Category = "test name; " + GenerateNumber();
                this.Price = this.GenerateNumber();

            }

            private float GenerateNumber()
            {
                Random random = new Random();
                return random.Next(20, 100);
            }
        }
    }
}
 