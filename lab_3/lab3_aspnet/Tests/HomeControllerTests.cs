using Asp_net_Lab_1.Controllers;
using Asp_net_Lab_1.Models;
using Asp_net_Lab_1.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace lab3_aspnet.Tests
{
    public class HomeControllerTests
    {
        private readonly Mock<ILogger<HomeController>> _mockLogger;
        private readonly Mock<IStringLocalizer<Texts>> _mockLocalizer;
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            _mockLogger = new Mock<ILogger<HomeController>>();
            _mockLocalizer = new Mock<IStringLocalizer<Texts>>();
            _controller = new HomeController(_mockLogger.Object, _mockLocalizer.Object);

            // Set up ControllerContext for accessing ViewBag
            _controller.ControllerContext = new ControllerContext();
        }

        [Fact]
        public void Index_Returns_ViewResult_With_Users()
        {
            // Arrange
            _mockLocalizer.Setup(l => l["Автомобільні салони"]).Returns(new LocalizedString("Автомобільні салони", "Car Dealerships"));
            DataEmulator.Users = new List<User> { new User { Id = 1, FullName = "Audi" } };
            DataEmulator.Users = new List<User> { new User { Id = 2, FullName = "BMW" } };
            DataEmulator.Users = new List<User> { new User { Id = 3, FullName = "Mercedes-Benz" } };

            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<User>>(viewResult.Model);
            Assert.Single(model);
            Assert.Equal("Car Dealerships", _controller.ViewBag.Користувачі);
        }

        [Fact]
        public void CreateUser_Returns_ViewResult()
        {
            // Act
            var result = _controller.CreateUser();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void EditUser_Returns_NotFound_When_User_Not_Found()
        {
            // Arrange
            DataEmulator.Users = new List<User>();

            // Act
            var result = _controller.EditUser(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void EditUser_Returns_ViewResult_When_User_Found()
        {
            // Arrange
            var user = new User { Id = 1, FullName = "Audi" };
            var user1 = new User { Id = 2, FullName = "BMW" };
            var user2 = new User { Id = 3, FullName = "Mercedes-Benz" };
            DataEmulator.Users = new List<User> { user };

            // Act
            var result = _controller.EditUser(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("EditCarSalon", viewResult.ViewName);
            Assert.Equal(user, viewResult.Model);
        }

        [Fact]
        public void DeleteUser_Returns_NotFound_When_User_Not_Found()
        {
            // Arrange
            DataEmulator.Users = new List<User>();

            // Act
            var result = _controller.DeleteUser(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteUser_Returns_ViewResult_When_User_Found()
        {
            // Arrange
            var user = new User { Id = 1, FullName = "Audi" };
            var user1 = new User { Id = 2, FullName = "BMW" };
            var user2 = new User { Id = 3, FullName = "Mercedes-Benz" };
            DataEmulator.Users = new List<User> { user };

            // Act
            var result = _controller.DeleteUser(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(user, viewResult.Model);
        }

        [Fact]
        public void Privacy_Returns_ViewResult_With_Products()
        {
            // Arrange
            DataEmulator.Products = new List<Product> { new Product { Id = 1, Name = "Audi Q8" } };
            DataEmulator.Products = new List<Product> { new Product { Id = 2, Name = "BMW IX" } };
            DataEmulator.Products = new List<Product> { new Product { Id = 3, Name = "MB AMG 63 S" } };

            // Act
            var result = _controller.Privacy();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);
            Assert.Single(model);
        }

        [Fact]
        public void CreateProd_Returns_ViewResult()
        {
            // Act
            var result = _controller.CreateProd();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void EditProd_Returns_NotFound_When_Product_Not_Found()
        {
            // Arrange
            DataEmulator.Products = new List<Product>();

            // Act
            var result = _controller.EditProd(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void EditProd_Returns_ViewResult_When_Product_Found()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Audi Q8" };
            var product2 = new Product { Id = 1, Name = "BMW IX" };
            var product3 = new Product { Id = 1, Name = "MB AMG 63 S" };
            DataEmulator.Products = new List<Product> { product };

            // Act
            var result = _controller.EditProd(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(product, viewResult.Model);
        }

        [Fact]
        public void DeleteProd_Returns_NotFound_When_Product_Not_Found()
        {
            // Arrange
            DataEmulator.Products = new List<Product>();

            // Act
            var result = _controller.DeleteProd(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteProd_Returns_ViewResult_When_Product_Found()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Audi Q8" };
            var product2 = new Product { Id = 1, Name = "BMW IX" };
            var product3 = new Product { Id = 1, Name = "MB AMG 63 S" };
            DataEmulator.Products = new List<Product> { product };

            // Act
            var result = _controller.DeleteProd(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(product, viewResult.Model);
        }

        [Fact]
        public void Order_Returns_ViewResult_With_Orders()
        {
            // Arrange
            DataEmulator.Orders = new List<Order> { new Order { Id = 1, ProductName = "Order1" } };
            DataEmulator.Orders = new List<Order> { new Order { Id = 2, ProductName = "Order2" } };
            DataEmulator.Orders = new List<Order> { new Order { Id = 3, ProductName = "Order3" } };

            // Act
            var result = _controller.Order();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Order>>(viewResult.Model);
            Assert.Single(model);
        }

        [Fact]
        public void CreateOrder_Returns_ViewResult()
        {
            // Act
            var result = _controller.CreateOrder();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void EditOrder_Returns_NotFound_When_Order_Not_Found()
        {
            // Arrange
            DataEmulator.Orders = new List<Order>();

            // Act
            var result = _controller.EditOrder(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void EditOrder_Returns_ViewResult_When_Order_Found()
        {
            // Arrange
            var order = new Order { Id = 1, ProductName = "Order1" };
            var order2 = new Order { Id = 1, ProductName = "Order2" };
            var order3 = new Order { Id = 1, ProductName = "Order3" };
            DataEmulator.Orders = new List<Order> { order };

            // Act
            var result = _controller.EditOrder(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("EditOrder", viewResult.ViewName);
            Assert.Equal(order, viewResult.Model);
        }

        [Fact]
        public void DeleteOrder_Returns_NotFound_When_Order_Not_Found()
        {
            // Arrange
            DataEmulator.Orders = new List<Order>();

            // Act
            var result = _controller.DeleteOrder(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteOrder_Returns_ViewResult_When_Order_Found()
        {
            // Arrange
            var order = new Order { Id = 1, ProductName = "Order1" };
            var order2 = new Order { Id = 1, ProductName = "Order2" };
            var order3 = new Order { Id = 1, ProductName = "Order3" };
            DataEmulator.Orders = new List<Order> { order };

            // Act
            var result = _controller.DeleteOrder(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(order, viewResult.Model);
        }
    }
}