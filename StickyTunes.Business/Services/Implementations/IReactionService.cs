using StickyTunes.Business.DTOs.Reaction;

namespace StickyTunes.Business.Services.Implementations;

public interface IReactionService
{
    Task AddAsync(CreateReactionRequest request, int commentId, string userId);
    Task<ICollection<GetReactionResponse>> GetAllByCommentIdAsync(int commentId);
}