using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameStore.WUI.Models;
using System.Web.Mvc;
using GameStore.WUI.HtmlHelpers;
using Moq;
using GameStore.WUI.Models.Abstract;
using GameStore.WUI.Controllers;
using System.Linq;

namespace GameStore.UnitTests
{
    /// <summary>
    /// Summary description for PageLinksUnitTest
    /// </summary>
    [TestClass]
    public class PageLinksUnitTest
    {
        public PageLinksUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
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
        public void Can_Paginate()
        {
            // Организация (arrange)
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
              {
                  new Game { Id = 1, Name = "Игра1"},
                  new Game {Id = 2, Name = "Игра2"},
                  new Game {Id = 3, Name = "Игра3"},
                  new Game { Id = 4, Name = "Игра4"},
                  new Game { Id = 5, Name = "Игра5"}
              });
            GameController controller = new GameController(mock.Object);
            controller.totalPagesCount = 3;

            // Действие (act)
            GamesListViewModel result = controller.List(null, 2).Model as GamesListViewModel;

            // Утверждение
            List<Game> games = result.Games.ToList();
            Assert.IsTrue(games.Count == 2);
            Assert.AreEqual(games[0].Name, "Игра4");
            Assert.AreEqual(games[1].Name, "Игра5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {

            // Организация - определение вспомогательного метода HTML - это необходимо
            // для применения расширяющего метода
            HtmlHelper myHelper = null;

            // Организация - создание объекта PagingInfo
            PagingInfo pagingInfo = new PagingInfo(2, 10, 28);

            // Организация - настройка делегата с помощью лямбда-выражения
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Действие
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Организация (arrange)
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
    {
        new Game { Id = 1, Name = "Игра1"},
        new Game { Id = 2, Name = "Игра2"},
        new Game { Id = 3, Name = "Игра3"},
        new Game { Id = 4, Name = "Игра4"},
        new Game { Id = 5, Name = "Игра5"}
    });
            GameController controller = new GameController(mock.Object);
            controller.totalPagesCount = 3;

            // Act
            GamesListViewModel result
                = controller.List(null, 2).Model as GamesListViewModel;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPageNumber, 2);
            Assert.AreEqual(pageInfo.ItemsPerPageCount, 3);
            Assert.AreEqual(pageInfo.TotalItemsCount, 5);
            Assert.AreEqual(pageInfo.TotalPagesCount, 2);
        }


        [TestMethod]
        public void Can_Filter_Games()
        {
            // Организация (arrange)
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
    {
        new Game { Id = 1, Name = "Игра1", Category="Cat1"},
        new Game { Id = 2, Name = "Игра2", Category="Cat2"},
        new Game { Id = 3, Name = "Игра3", Category="Cat1"},
        new Game { Id = 4, Name = "Игра4", Category="Cat2"},
        new Game { Id = 5, Name = "Игра5", Category="Cat3"}
    });
            GameController controller = new GameController(mock.Object);
            controller.totalPagesCount = 3;

            // Action
            List<Game> result = (controller.List("Cat2", 1).Model as GamesListViewModel)
                .Games.ToList();

            // Assert
            Assert.AreEqual(result.Count(), 2);
            Assert.IsTrue(result[0].Name == "Игра2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "Игра4" && result[1].Category == "Cat2");
        }


        [TestMethod]
        public void Generate_Category_Specific_Game_Count()
        {
            /// Организация (arrange)
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
    {
        new Game { Id = 1, Name = "Игра1", Category="Cat1"},
        new Game { Id = 2, Name = "Игра2", Category="Cat2"},
        new Game { Id = 3, Name = "Игра3", Category="Cat1"},
        new Game { Id = 4, Name = "Игра4", Category="Cat2"},
        new Game { Id = 5, Name = "Игра5", Category="Cat3"}
    });
            GameController controller = new GameController(mock.Object);
            controller.totalPagesCount = 3;

            // Действие - тестирование счетчиков товаров для различных категорий
            int res1 = ((GamesListViewModel)controller.List("Cat1").Model).PagingInfo.TotalItemsCount;
            int res2 = ((GamesListViewModel)controller.List("Cat2").Model).PagingInfo.TotalItemsCount;
            int res3 = ((GamesListViewModel)controller.List("Cat3").Model).PagingInfo.TotalItemsCount;
            int resAll = ((GamesListViewModel)controller.List(null).Model).PagingInfo.TotalItemsCount;

            // Утверждение
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);
        }
    }
}
