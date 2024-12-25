using StickyTunes.Business.DTOs.Comment;

namespace StickyTunes.Business.Services.Interfaces;

public interface ICommentService
{
    public Task<List<GetCommentResponse>> GetAllAsync();
    public Task<GetCommentResponse> GetByIdAsync(int id);
    public Task CreateAsync(CreateCommentRequest request, string userId);
    public Task DeleteAsync(int id);
}