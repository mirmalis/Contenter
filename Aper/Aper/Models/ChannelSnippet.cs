using System.ComponentModel.DataAnnotations;

namespace Aper.Models;
public class ChannelSnippet: IIded<Guid>
{
  public DateTime CreatedAt { get; set; }
  public Guid Id { get; set; }
  [Required]
  public Channel Channel { get; set; } = default!;
  public string ChannelId { get; set; } = default!;

  public required DateTime PublishedAt { get; set; }
  public required string Title { get; set; }
  public required string Handle { get; set; }
  public required string Country { get; set; }
  public required string UploadsPlaylistId { get; set; }
}
