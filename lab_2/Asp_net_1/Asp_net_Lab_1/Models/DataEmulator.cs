namespace Asp_net_Lab_1.Models
{
    public class DataEmulator
    {
        public static List<User> Users { get; set; } = new List<User>
        {
            new User { Id = 1, FullName = "John Doe", Email = "john@example.com", PhoneNumber = "1234567890", Address = "123 Main St" },
            new User { Id = 2, FullName = "Jane Smith", Email = "jane@example.com", PhoneNumber = "0987654321", Address = "456 Elm St" }
        };
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Description = "Description of Product 1", Price = 10.99m },
            new Product { Id = 2, Name = "Product 2", Description = "Description of Product 2", Price = 20.99m }
        };
        public static List<Order> Orders { get; set; } = new List<Order>
        {
            new Order { Id = 1, UserId = 1, ProductName = "Product 1", TotalPrice = 10.99m },
            new Order { Id = 2, UserId = 2, ProductName = "Product 2", TotalPrice = 20.99m }
        };
        //coment
    }
}
