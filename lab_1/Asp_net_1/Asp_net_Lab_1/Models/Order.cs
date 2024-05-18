namespace Asp_net_Lab_1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
