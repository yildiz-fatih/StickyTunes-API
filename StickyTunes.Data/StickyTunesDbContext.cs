using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StickyTunes.Data.Models;

namespace StickyTunes.Data;

public class StickyTunesDbContext : IdentityDbContext<ApiUser, ApiRole, string>
{
    public StickyTunesDbContext(DbContextOptions<StickyTunesDbContext> options) : base(options) { }
    
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
}