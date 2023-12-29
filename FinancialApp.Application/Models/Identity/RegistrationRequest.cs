

using System.ComponentModel.DataAnnotations;

namespace FinancialApp.Application.Models.Identity;

public class RegistrationRequest
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string ConfirmPassword { get; set; }
}
