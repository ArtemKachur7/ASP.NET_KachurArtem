using Asp_net_Lab_1.Resources;
using System.ComponentModel.DataAnnotations;

namespace Asp_net_Lab_1.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "FullName", ResourceType = typeof(SharedResources))]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Email", ResourceType = typeof(SharedResources))]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Address", ResourceType = typeof(SharedResources))]
        public string Address { get; set; }
        [Required]
        [Display(Name = "PhoneNumber", ResourceType = typeof(SharedResources))]
        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
