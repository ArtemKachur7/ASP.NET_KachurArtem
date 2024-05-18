using Asp_net_Lab_1.Resources;
using System.ComponentModel.DataAnnotations;

namespace Asp_net_Lab_1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name", ResourceType = typeof(SharedResources))]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description", ResourceType = typeof(SharedResources))]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Price", ResourceType = typeof(SharedResources))]
        public decimal Price { get; set; }

    }
}
