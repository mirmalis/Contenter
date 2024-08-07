namespace Aper.Api.Services._0Brokers.TruthBrokers.Models;

public class PlaylistItemDetails
{
  public required string Id { get; set; }
  public required DateTimeOffset PublishedAt { get; set; }
  public required long? Position { get; set; }
  public required BasicPlaylistInfo Playlist { get; set; }
  public required BasicVideoInfo Video { get; set; }
  public required BasicChannelInfo Channel { get; set; }
}
