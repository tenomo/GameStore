﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameStore.WUI.Models.Abstract;
using Moq;
using System.Collections.Generic;
using GameStore.WUI.Models;
using GameStore.WUI.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace GameStore.UnitTests
{
    [TestClass]
    public class AdminControllerUnitTest
    {
        [TestClass]
        public class AdminTests
        {
            [TestMethod]
            public void Index_Contains_All_Games()
            {
                // Организация - создание имитированного хранилища данных
                Mock<IGameRepository> mock = new Mock<IGameRepository>();
                mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game { Id = 1, Name = "Игра1"},
                new Game { Id = 2, Name = "Игра2"},
                new Game { Id = 3, Name = "Игра3"},
                new Game { Id = 4, Name = "Игра4"},
                new Game { Id = 5, Name = "Игра5"}
            });

                // Организация - создание контроллера
                AdminController controller = new AdminController(mock.Object);

                // Действие
                List<Game> result = (controller.Index().
                    ViewData.Model as IEnumerable<Game>).ToList();

                // Утверждение
                Assert.IsNotNull(result);
                Assert.AreEqual(result.Count(), 5);
                Assert.AreEqual("Игра1", result[0].Name);
                Assert.AreEqual("Игра2", result[1].Name);
                Assert.AreEqual("Игра3", result[2].Name);
            }
        }
        [TestMethod]
        public void Can_Edit_Game()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
    {
        new Game { Id = 1, Name = "Игра1"},
        new Game { Id = 2, Name = "Игра2"},
        new Game { Id = 3, Name = "Игра3"},
        new Game { Id = 4, Name = "Игра4"},
        new Game { Id = 5, Name = "Игра5"}
    });

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Действие
            Game game1 = controller.Edit(1).ViewData.Model as Game;
            Game game2 = controller.Edit(2).ViewData.Model as Game;
            Game game3 = controller.Edit(3).ViewData.Model as Game;

            // Assert
            Assert.AreEqual(1, game1.Id);
            Assert.AreEqual(2, game2.Id);
            Assert.AreEqual(3, game3.Id);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Game()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
    {
        new Game { Id = 1, Name = "Игра1"},
        new Game { Id = 2, Name = "Игра2"},
        new Game { Id = 3, Name = "Игра3"},
        new Game { Id = 4, Name = "Игра4"},
        new Game { Id = 5, Name = "Игра5"}
    });

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Действие
            Game result = controller.Edit(6).ViewData.Model as Game;

            // Assert
        }

        // ...

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IGameRepository> mock = new Mock<IGameRepository>();

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Организация - создание объекта Game
            Game game = new Game { Name = "Test" };

            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(game);

            // Утверждение - проверка того, что к хранилищу производится обращение
            mock.Verify(m => m.SaveGame(game));

            // Утверждение - проверка типа результата метода
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IGameRepository> mock = new Mock<IGameRepository>();

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Организация - создание объекта Game
            Game game = new Game { Name = "Test" };

            // Организация - добавление ошибки в состояние модели
            controller.ModelState.AddModelError("error", "error");

            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(game);

            // Утверждение - проверка того, что обращение к хранилищу НЕ производится 
            mock.Verify(m => m.SaveGame(It.IsAny<Game>()), Times.Never());

            // Утверждение - проверка типа результата метода
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
       
    }
}
