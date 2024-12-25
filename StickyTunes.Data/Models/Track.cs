namespace StickyTunes.Data.Models;

public class Track
{
    public int Id { get; set; }
    public string SpotifyTrackId { get; set; }
    public string Name { get; set; }
    public string AlbumName { get; set; }
    public ICollection<Artist> Artists { get; set; } = new List<Artist>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}