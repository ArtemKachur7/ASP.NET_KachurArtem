using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using System.ComponentModel.DataAnnotations;
using Asp_net_Lab_1.Models;
using Asp_net_Lab_1.Resources;

namespace Asp_net_Lab_1.Models
{
    public class Order
    {
        
        
        
        public int Id { get; set; }
        [Display(Name = "UserId", ResourceType = typeof(CreateOrder))]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "ProductName", ResourceType = typeof(CreateOrder))]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "TotalPrice", ResourceType = typeof(CreateOrder))]
        public decimal TotalPrice { get; set; }
        

    }
}
