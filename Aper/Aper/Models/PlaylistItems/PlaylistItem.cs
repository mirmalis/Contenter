using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Aper.Models.Playlists;
using Aper.Models.Videos;

namespace Aper.Models.PlaylistItems;
public class PlaylistItem: IIded<string>, IAuditable
{
  public DateTimeOffset CreatedDate { get; set; }
  public DateTimeOffset UpdatedDate { get; set; }
  public DateTimeOffset PublishedAt { get; set; }
  public string Id { get; set; } = default!;
  [Required]
  public Playlist Playlist { get; set; } = default!;
  public string PlaylistId { get; set; } = default!;
  public long? Position { get; set; }
  [Required]
  public Video Video { get; set; } = default!;
  public string VideoId { get; set; } = default!;

  public Channels.Channel? Channel { get; set; }
  public string? ChannelId { get; set; }
  [JsonIgnore]
  public DateTimeOffset? DeletedAt { get; set; }
}
