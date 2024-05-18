using Asp_net_Lab_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Asp_net_Lab_1.Resources;
using Microsoft.Extensions.Localization;

namespace Asp_net_Lab_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<Texts> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<Texts> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var users = DataEmulator.Users;
            ViewBag.Користувачі = _localizer["Користувачі"].Value;
            return View(users);
        }


        public IActionResult CreateUser()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                // Додати нового користувача до списку
                DataEmulator.Users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult EditUser(int id)
        {
            var user = DataEmulator.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View("EditUser", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = DataEmulator.Users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser != null)
                {
                    existingUser.Id = user.Id;
                    existingUser.FullName = user.FullName;
                    existingUser.Email = user.Email;
                    existingUser.Address = user.Address;
                    existingUser.PhoneNumber = user.PhoneNumber;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            return View(user);
        }

        public IActionResult DeleteUser(int id)
        {
            var user = DataEmulator.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = DataEmulator.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                DataEmulator.Users.Remove(user);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }




        public IActionResult Privacy()
        {
            var products = DataEmulator.Products;
            return View(products);
        }

        public IActionResult CreateProd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProd(Product product)
        {
            if (ModelState.IsValid)
            {
                // Додати новий продукт до списку
                DataEmulator.Products.Add(product);
                return RedirectToAction(nameof(Privacy));
            }
			return Redirect(ViewBag.ReturnUrl);


        }

        public IActionResult EditProd(int id)
        {
            var product = DataEmulator.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProd(Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = DataEmulator.Products.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct != null)
                {
                    // Оновити існуючий продукт
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    return RedirectToAction(nameof(Privacy));
                }
                else
                {
                    return NotFound();
                }
            }
            return View(product);
        }

        public IActionResult DeleteProd(int id)
        {
            var product = DataEmulator.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("DeleteProd")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed_Prod(int id)
        {
            var product = DataEmulator.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                // Видалити продукт зі списку
                DataEmulator.Products.Remove(product);
                return RedirectToAction(nameof(Privacy));
            }
            else
            {
                return NotFound();
            }
        }








        public IActionResult Order()
        {
            var orders = DataEmulator.Orders;
            return View(orders);
        }

        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                // Додати нове замовлення до списку
                DataEmulator.Orders.Add(order);
                return RedirectToAction(nameof(Order));
            }
            return View(order);
        }

        public IActionResult EditOrder(int id)
        {
            var order = DataEmulator.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View("EditOrder", order); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                var existingOrder = DataEmulator.Orders.FirstOrDefault(o => o.Id == order.Id);
                if (existingOrder != null)
                {
                    existingOrder.Id = order.Id;
                    existingOrder.UserId = order.UserId;
                    existingOrder.ProductName = order.ProductName;
                    existingOrder.TotalPrice = order.TotalPrice;
                    return RedirectToAction(nameof(Order));
                }
                else
                {
                    return NotFound();
                }
            }
            return View(order);
        }

        public IActionResult DeleteOrder(int id)
        {
            var order = DataEmulator.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed_Order(int id)
        {
            var order = DataEmulator.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                // Видалити замовлення зі списку
                DataEmulator.Orders.Remove(order);
                return RedirectToAction(nameof(Order));
            }
            else
            {
                return NotFound();
            }
        }










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
