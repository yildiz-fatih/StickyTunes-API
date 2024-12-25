namespace StickyTunes.Data.Models;

public class Reaction
{
    public int Id { get; set; }
    public string Emoji { get; set; }
    public DateTime DatePosted { get; set; }

    public string ApiUserId { get; set; }
    public ApiUser ApiUser { get; set; }

    public int CommentId { get; set; }
    public Comment Comment { get; set; }
}