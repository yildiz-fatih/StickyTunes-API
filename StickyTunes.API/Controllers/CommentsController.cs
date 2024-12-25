using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StickyTunes.Business.DTOs.Comment;
using StickyTunes.Business.DTOs.Reaction;
using StickyTunes.Business.Services.Implementations;
using StickyTunes.Business.Services.Interfaces;

namespace StickyTunes.API.Controllers;

[ApiController]
[Route("api/comments")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly IReactionService _reactionService;

    public CommentsController(ICommentService commentService, IReactionService reactionService)
    {
        _commentService = commentService;
        _reactionService = reactionService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentService.GetAllAsync();

        return Ok(comments);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await _commentService.GetByIdAsync(id);

        if (comment == null)
            return NotFound();
        
        return Ok(comment);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommentRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        await _commentService.CreateAsync(request, userId);
        
        return CreatedAtAction(nameof(GetById), new { id = userId}, request);
    }

    [Authorize]
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _commentService.DeleteAsync(id);
        
        return NoContent();
    }

    [Authorize]
    [HttpPost("{id}/reactions")]
    public async Task<IActionResult> AddReaction([FromRoute] int id, [FromBody] CreateReactionRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        await _reactionService.AddAsync(request, id, userId);
        
        return NoContent();
    }

    [HttpGet("{id}/reactions")]
    public async Task<IActionResult> GetReactions([FromRoute] int id)
    {
        var reactions = await _reactionService.GetAllByCommentIdAsync(id);
        
        return Ok(reactions);
    }
}