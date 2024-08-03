using System.Text.Json.Serialization;

using Aper.Models.Channels;
using Aper.Models.PlaylistItems;

namespace Aper.Models.Playlists;

public class Playlist: IIded<string>, IAuditable
{
  public DateTimeOffset CreatedDate { get; set; }
  public DateTimeOffset UpdatedDate { get; set; }
  public string Id { get; set; }
  public DateTimeOffset PublishedAt { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public Channel Channel { get; set; }
  public string ChannelId { get; set; }
  public AccessStates? PrivacyStatus { get; set; }
  public long? CurrentItemsCount { get; set; }
  [JsonIgnore]
  public List<PlaylistItem> PlaylistItems { get; set; } = [];
}
