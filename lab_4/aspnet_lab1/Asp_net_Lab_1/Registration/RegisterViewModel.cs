using System.ComponentModel.DataAnnotations;
namespace Asp_net_Lab_1.Registration;


public class RegisterViewModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}

