namespace Aper.Api.Brokers.YoutubeApiBrokers.Models;

public class VideoDetails
{
  public required string Id { get; set; }
  public required DateTime PublishedAt { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required BasicChannelInfo Channel { get; set; }
}
