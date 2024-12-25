using StickyTunes.Data.Models;

namespace StickyTunes.Data.Repositories.Interfaces;

public interface ICommentRepository
{
    public Task<ICollection<Comment>> GetAllAsync();
    public Task<Comment> GetByIdAsync(int id);
    public Task CreateAsync(Comment comment);
    public Task DeleteAsync(int id);
}