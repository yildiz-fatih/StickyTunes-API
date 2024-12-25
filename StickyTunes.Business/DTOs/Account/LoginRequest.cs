using System.ComponentModel.DataAnnotations;

namespace StickyTunes.Business.DTOs.Account;

public class LoginRequest
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public bool RememberMe { get; set; }
}