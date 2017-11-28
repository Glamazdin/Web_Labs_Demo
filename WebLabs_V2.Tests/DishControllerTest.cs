using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebLabs_V3.Controllers;
using WebLabs_V3.Models;
using WebLabs_V3.DAL.Entities;
using WebLabs_V3.DAL.Interfaces;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;

namespace WebLabs_V3.Tests
{
    /// <summary>
    /// Сводное описание для DishControllerTest
    /// </summary>
    [TestClass]
    public class DishControllerTest
    {
        public DishControllerTest()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
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

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PagingTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Dish>>();
            mock.Setup(r => r.GetAll())
                .Returns(new List<Dish> {
                    new Dish { DishId=1 },
                    new Dish { DishId=2 },
                    new Dish { DishId=3 },
                    new Dish { DishId=4 },
                    new Dish { DishId=5 },
                });
            // Создание объекта контроллера
            var controller = new DishController(mock.Object);

            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;
                
            // Act
            // Вызов метода List 
            var view = controller.List(null, 2) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Dish> model = view.Model as PageListViewModel<Dish>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].DishId);
            Assert.AreEqual(5, model[1].DishId);
        }
        [TestMethod]
        public void CategoryTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Dish>>();
            mock.Setup(r => r.GetAll())
                .Returns(new List<Dish> {
                    new Dish { DishId=1, GroupName="1" },
                    new Dish { DishId=2, GroupName="2" },
                    new Dish { DishId=3, GroupName="1" },
                    new Dish { DishId=4, GroupName="2" },
                    new Dish { DishId=5, GroupName="2" },
                });
            // Создание объекта контроллера
            var controller = new DishController(mock.Object);

            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            // Вызов метода List 
            var view = controller.List("1", 1) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Dish> model = view.Model as PageListViewModel<Dish>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].DishId);
            Assert.AreEqual(3, model[1].DishId);
        }

        [TestMethod]
        public void DefaultRouteTest()
        {
            // Arrange
            // Макет Http - контекста
            var mockContext = new Mock<HttpContextBase>();
            mockContext
            .Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
            .Returns("~/");

            // Создание коллекции маршрутов и регистрация маршрутов
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //Act
            //Получение данных маршрута
            var result = routes.GetRouteData(mockContext.Object);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", result.Values["controller"]);
            Assert.AreEqual("Index", result.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, result.Values["id"]);
        }

    }
}
