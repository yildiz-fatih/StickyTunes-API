using Microsoft.EntityFrameworkCore;
using StickyTunes.Data.Models;
using StickyTunes.Data.Repositories.Interfaces;

namespace StickyTunes.Data.Repositories.Implementations;

public class CommentRepository : ICommentRepository
{
    private readonly StickyTunesDbContext _context;

    public CommentRepository(StickyTunesDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment> GetByIdAsync(int id)
    {
        return await _context.Comments.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task CreateAsync(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        _context.Comments.Remove(await GetByIdAsync(id));
        await _context.SaveChangesAsync();
    }
}