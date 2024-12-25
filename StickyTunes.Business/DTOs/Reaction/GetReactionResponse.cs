namespace StickyTunes.Business.DTOs.Reaction;

public class GetReactionResponse
{
    public int Id { get; set; }
    public string Emoji { get; set; }
    public DateTime DatePosted { get; set; }
    public string ApiUserId { get; set; }
}