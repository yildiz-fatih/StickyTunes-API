using Microsoft.EntityFrameworkCore;
using StickyTunes.Data.Models;
using StickyTunes.Data.Repositories.Interfaces;

namespace StickyTunes.Data.Repositories.Implementations;

public class ReactionRepository : IReactionRepository
{
    private readonly StickyTunesDbContext _context;

    public ReactionRepository(StickyTunesDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Reaction reaction)
    {
        _context.Reactions.Add(reaction);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Reaction>> GetAllByCommentIdAsync(int commentId)
    {
        return await _context.Reactions.ToListAsync();
    }
}