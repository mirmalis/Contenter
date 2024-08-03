using System.Text.Json.Serialization;

using Aper.Models.PlaylistItems;
using Aper.Models.Playlists;
using Aper.Models.Videos;

namespace Aper.Models.Channels;

public class Channel: IIded<string>, IAuditable
{
  public DateTimeOffset CreatedDate { get; set; }
  public DateTimeOffset UpdatedDate { get; set; }

  public string Id { get; set; } = default!;
  public string Title { get; set; } = default!;
  public DateTimeOffset? PublishedAt { get; set; }

  public string? UploadsPlaylistId { get; set; }
  public string? Handle { get; set; }
  public string? Country { get; set; }

  [JsonIgnore]
  public List<Video> Videos { get; set; } = [];
  [JsonIgnore]
  public List<Playlist> Playlists { get; set; } = [];
  [JsonIgnore]
  public List<PlaylistItem> PlaylistItems { get; set; } = [];

  [JsonIgnore]
  public List<ChannelSnippet> Snippets { get; set; } = [];
}
