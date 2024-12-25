using StickyTunes.Data.Models;

namespace StickyTunes.Data.Repositories.Interfaces;

public interface IReactionRepository
{
    Task AddAsync(Reaction reaction);
    Task<ICollection<Reaction>> GetAllByCommentIdAsync(int commentId);
}
