using System.ComponentModel.DataAnnotations;

namespace StickyTunes.Business.DTOs.Account;

public class RegisterRequest
{
    [Required]
    public string FullName { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}