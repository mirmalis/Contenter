namespace Aper.Api.Brokers.YoutubeApiBrokers.Models;

public class PlaylistItemDetails
{
  public required string Id { get; set; }
  public required DateTime PublishedAt { get; set; }
  public required long? Position { get; set; }
  public required BasicPlaylistInfo Playlist { get; set; }
  public required BasicVideoInfo Video { get; set; }
}
