using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Aper.Models.Channels;

namespace Aper.Models;
public class ChannelSnippet: IIded<Guid>, IAuditable
{
  [JsonIgnore]
  public DateTimeOffset CreatedDate { get; set; }
  [JsonIgnore]
  public DateTimeOffset UpdatedDate { get; set; }
  [JsonIgnore]
  public Guid CreatedBy { get; set; }
  [JsonIgnore]
  public Guid UpdatedBy { get; set; }

  public required DateTimeOffset PublishedAt { get; set; }
  public Guid Id { get; set; }
  [Required]
  public Channel Channel { get; set; } = default!;
  public string ChannelId { get; set; } = default!;

  public required string Title { get; set; }
  public required string Handle { get; set; }
  public required string Country { get; set; }
  public required string UploadsPlaylistId { get; set; }
}
