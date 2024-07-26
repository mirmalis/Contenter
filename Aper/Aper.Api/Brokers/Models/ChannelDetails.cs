namespace Aper.Api.Brokers.Models;

public class ChannelDetails
{
  public required string Id { get; set; }
  public required string Handle { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required DateTime? Since { get; set; }
  public required string Country { get; set; }
  public required string UploadsPlaylist { get; set; }
  public required string WatchLaterPlaylist { get; set; }
  public required string FavoritesPlaylist { get; set; }
  public required string LikedPlaylist { get; set; }
}
