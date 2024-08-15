namespace Contenter.Models.Views;

public class YoutubeVideo
{
  public class ChannelIdentifier
  {
    public class PlaylistIdentifier
    {
      public required string Id { get; init; }
    }
    public string Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Href => $"https://www.youtube.com/channel/{this.Id}";
    public PlaylistIdentifier? Uploads { get; set ; }
  }
  
  public string Id { get; set; } = default!;
  public DateTime PublishedAt { get; set; }
  public string Title { get; set; } = default!;
  public string? Description { get; set; }
  public ChannelIdentifier Channel { get; set; } = default!;
  public override string ToString()
  {
    return $"Video id={Id} (Author: {Channel.Id}) {PublishedAt} - {Title}";
  }
  public string Href => HrefFormat(Id);
  public static string HrefFormat(string v) => $"https://www.youtube.com/watch?v={v}";
}
