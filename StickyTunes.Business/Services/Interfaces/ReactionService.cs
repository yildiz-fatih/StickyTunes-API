using StickyTunes.Business.DTOs.Reaction;
using StickyTunes.Business.Services.Implementations;
using StickyTunes.Data.Models;
using StickyTunes.Data.Repositories.Interfaces;

namespace StickyTunes.Business.Services.Interfaces;

public class ReactionService : IReactionService
{
    private readonly IReactionRepository _reactionRepository;

    public ReactionService(IReactionRepository reactionRepository)
    {
        _reactionRepository = reactionRepository;
    }

    public async Task AddAsync(CreateReactionRequest request, int commentId, string userId)
    {
        var reaction = new Reaction()
        {
            Emoji = request.Emoji,
            DatePosted = DateTime.UtcNow,
            CommentId = commentId,
            ApiUserId = userId
        };
        
        await _reactionRepository.AddAsync(reaction);
    }

    public async Task<ICollection<GetReactionResponse>> GetAllByCommentIdAsync(int commentId)
    {
        var reactions = await _reactionRepository.GetAllByCommentIdAsync(commentId);

        return reactions.Select(r => new GetReactionResponse()
            {
                Id = r.Id,
                Emoji = r.Emoji,
                DatePosted = r.DatePosted,
                ApiUserId = r.ApiUserId
            })
            .ToList();
    }
}