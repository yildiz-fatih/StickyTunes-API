using Microsoft.AspNetCore.Identity;

namespace StickyTunes.Data.Models;

public class ApiUser : IdentityUser
{
    public string FullName { get; set; }
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}