using System.ComponentModel.DataAnnotations;

namespace Aper.Models;
public class PlaylistItem: IIded<string>
{
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Id { get; set; } = default!;
  public DateTime PublishedAt { get; set; }
  [Required]
  public Playlist Playlist { get; set; } = default!;
  public string PlaylistId { get; set; } = default!;
  public long? Position { get; set; }
  [Required]
  public Video Video { get; set; } = default!;
  public string VideoId { get; set; } = default!;
}
