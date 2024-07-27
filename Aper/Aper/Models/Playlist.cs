namespace Aper.Models;

public class Playlist
{
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Id { get; set; }
  public DateTime PublishedAt { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public Channel Channel { get; set; }
  public string ChannelId { get; set; }
  public AccessStates? PrivacyStatus { get; set; }
  public long? CurrentItemsCount { get; set; }

  public List<PlaylistItem> PlaylistItems { get; set; } = [];
}
