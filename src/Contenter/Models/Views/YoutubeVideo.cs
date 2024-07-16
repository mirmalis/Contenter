namespace Contenter.Models.Views;

public class YoutubeVideo
{
  public class ChannelIdentifier
  {
    public string Id { get; set; } = default!;
  }
  public string Id { get; set; } = default!;
  public ChannelIdentifier Author { get; set; } = default!;
  public DateTime PublishedAt { get; set; }
  public string Title { get; set; } = default!;
  public override string ToString()
  {
    return $"Video id={Id} (Author: {Author.Id}) {PublishedAt} - {Title}";
  }
  public string Href => HrefFormat(Id);
  public static string HrefFormat(string v) => $"https://www.youtube.com/watch?v={v}";
}
