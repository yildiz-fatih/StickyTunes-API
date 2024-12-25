namespace StickyTunes.Data.Models;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime DatePosted { get; set; }
    
    public int TrackId { get; set; }
    public Track Track { get; set; }
    
    public string ApiUserId { get; set; }
    public ApiUser ApiUser { get; set; }
    
    public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
}