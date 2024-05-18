using Microsoft.AspNetCore.Cors;

namespace Asp_net_Lab_1.Models
{
    public class DataEmulator
    {
        
        public static List<User> Users { get; set; } = new List<User>
        {
            new User { Id = 1, FullName = "Audi", Email = "Audi@gmail.com", PhoneNumber = "7777", Address = "Audi St RS7" },
            new User { Id = 2, FullName = "BMW", Email = "BMW@gmail.com", PhoneNumber = "+3802452454", Address = "Geroyiv 101" },
            new User { Id = 3, FullName = "Mercedes-Benz", Email = "MB@gmail.com", PhoneNumber = "+3802454545", Address = "Managarova 11" },

        };
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Audi Q8", Description = "Турбодизель 4.2с до 100км/год", Price = 3000000.0m  },
            new Product { Id = 2, Name = "BMW IX", Description = "Електро, повний привід", Price = 1500000.0m },
            new Product { Id = 3, Name = "MB AMG 63 S", Description = "Новий спортрежим 820 к.с , 2.5 до 100км/год", Price = 2500000.0m }
        };
        public static List<Order> Orders { get; set; } = new List<Order>
        {
            new Order { Id = 1, UserId = 1, ProductName = "Audi Q8", TotalPrice = 3000000.0m },
            new Order { Id = 2, UserId = 2, ProductName = "BMW IX", TotalPrice = 1500000.0m },
            new Order { Id = 1, UserId = 1, ProductName = "MB AMG 63 S", TotalPrice = 2500000.0m },
        };
    }
}
