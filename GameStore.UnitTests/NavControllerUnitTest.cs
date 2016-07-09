using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameStore.WUI.Models.Abstract;
using GameStore.WUI.Models;
using System.Collections.Generic;
using GameStore.WUI.Controllers;

namespace GameStore.UnitTests
{
    [TestClass]
    public class NavControllerUnitTest
    {
        [TestMethod]
        public void Can_Create_Categories()
        {
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game> {
        new Game { Id = 1, Name = "Игра1", Category = "Симулятор" },
        new Game { Id = 2, Name = "Игра2", Category = "Симулятор" },
        new Game { Id = 3, Name = "Игра3", Category = "Шутер" },
        new Game { Id = 4, Name = "Игра4", Category = "RPG" },
    });

            // Организация - создание контроллера
            NavController target = new NavController(mock.Object);

            // Действие - получение набора категорий
            List<string> results = new List<string>(target.Menu().Model as IEnumerable<string>);

            // Утверждение
            Assert.AreEqual(results.Count, 3);
            Assert.AreEqual(results[0], "RPG");
            Assert.AreEqual(results[1], "Симулятор");
            Assert.AreEqual(results[2], "Шутер");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Организация - создание имитированного хранилища
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new Game[] {
        new Game { Id = 1, Name = "Игра1", Category="Симулятор"},
        new Game { Id = 2, Name = "Игра2", Category="Шутер"}
    });

            // Организация - создание контроллера
            NavController NavControllertarget = new NavController(mock.Object);

            // Организация - определение выбранной категории
            string categoryToSelect = "Шутер";

            // Действие
            string result = NavControllertarget.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // Утверждение
            Assert.AreEqual(categoryToSelect, result);
        }
    }
}
