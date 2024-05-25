using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Asp_net_Lab_1.Registration;


public class ApplicationUser : IdentityUser 
{
   public int Id { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}

