namespace Aper.Models;

public class Video: IIded<string>
{
  public string Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public DateTime PublishedAt { get; set; }
  public Channel Channel { get; set; }
  public string ChannelId { get; set; } 
  public string Title { get; set; }
  public string Description { get; set; }

  public List<PlaylistItem> PlaylistAssignments { get; set; } = [];
}
