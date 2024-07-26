namespace Aper.Api.Youtube;
public class Video
{
  public string Id { get; init; }
  public ChannelIdentifier Author { get; init; }
  public DateTime PublishedAt { get; init; }
  public string Title { get; init; }
}
public class ChannelIdentifier
{
  public string Id { get; init; }
  public string Title { get; set; }
}
