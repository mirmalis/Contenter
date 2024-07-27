namespace Aper.Models;

public class Channel: IIded<string>
{
  public string Id { get; set; } = default!;
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public DateTime? PublishedAt { get; set; }
  public string Title { get; set; } = default!;

  public string? UploadsPlaylistId { get; set; }
  public string? Handle { get; set; }
  public string? Country { get; set; }

  public List<Video> Videos { get; set; } = [];
  public List<Playlist> Playlists { get; set; } = [];
  public List<PlaylistItem> PlaylistItems { get; set; } = [];

  public List<ChannelSnippet> Snippets { get; set; } = [];
}
 