namespace StickyTunes.Business.DTOs.Comment;

public class CreateCommentRequest
{
    public string SpotifyTrackUrl { get; set; }
    public string Text { get; set; }
}