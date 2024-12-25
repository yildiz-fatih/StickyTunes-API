namespace StickyTunes.Business.DTOs.Comment;

public class GetCommentResponse
{
    public int Id { get; set; }
    public string SpotifyTrackId { get; set; }
    public string Text { get; set; }
    public DateTime DatePosted { get; set; }
    public string ApiUserId { get; set; }
}