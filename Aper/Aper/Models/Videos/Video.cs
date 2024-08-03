using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Aper.Models.Channels;
using Aper.Models.PlaylistItems;

namespace Aper.Models.Videos;

public class Video: IIded<string>, IAuditable
{
  public DateTimeOffset CreatedDate { get; set; }
  public DateTimeOffset UpdatedDate { get; set; }
  public DateTimeOffset PublishedAt { get; set; }
  public string Id { get; set; }
  public string Title { get; set; }
  [JsonIgnore]
  public string? Description { get; set; }
  [Required]
  public Channel Channel { get; set; } = default!;
  public string ChannelId { get; set; } = default!;
  public AccessStates? PrivacyStatus { get; set; }
  [JsonIgnore]
  public List<PlaylistItem> PlaylistAssignments { get; set; } = [];
}
