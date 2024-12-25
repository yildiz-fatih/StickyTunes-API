using StickyTunes.Business.DTOs.Comment;
using StickyTunes.Business.Services.Interfaces;
using StickyTunes.Data.Models;
using StickyTunes.Data.Repositories.Interfaces;

namespace StickyTunes.Business.Services.Implementations;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly SpotifyService _spotifyService;

    public CommentService(ICommentRepository commentRepository, SpotifyService spotifyService)
    {
        _commentRepository = commentRepository;
        _spotifyService = spotifyService;
    }

    public async Task<List<GetCommentResponse>> GetAllAsync()
    {
        var comments = await _commentRepository.GetAllAsync();

        return comments.Select(comment => new GetCommentResponse
        {
            Id = comment.Id,
            SpotifyTrackId = comment.SpotifyTrackId,
            Text = comment.Text,
            DatePosted = comment.DatePosted,
            ApiUserId = comment.ApiUserId
        }).ToList();
    }
    
    public async Task<GetCommentResponse> GetByIdAsync(int id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        
        if (comment == null) { return null; }

        return new GetCommentResponse
        {
            Id = comment.Id,
            SpotifyTrackId = comment.SpotifyTrackId,
            Text = comment.Text,
            DatePosted = comment.DatePosted,
            ApiUserId = comment.ApiUserId
        };
    }
    
    public async Task CreateAsync(CreateCommentRequest request, string apiUserId)
    {
        var comment = new Comment()
        {
            Text = request.Text,
            SpotifyTrackId = _spotifyService.GetTrackId(request.SpotifyTrackUrl),
            DatePosted = DateTime.UtcNow,
            ApiUserId = apiUserId
        };
        
        await _commentRepository.CreateAsync(comment);
    }
    
    public async Task DeleteAsync(int id)
    {
        await _commentRepository.DeleteAsync(id);
    }
}