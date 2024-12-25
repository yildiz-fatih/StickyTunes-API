namespace StickyTunes.Data.Models;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string SpotifyTrackId { get; set; }
    public DateTime DatePosted { get; set; }
    
    public string ApiUserId { get; set; }
    public ApiUser ApiUser { get; set; }
}