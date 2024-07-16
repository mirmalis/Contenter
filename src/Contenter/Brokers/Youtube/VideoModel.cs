namespace Contenter.Brokers.Youtube;

public class VideoModel
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
    return $"Video id={this.Id} (Author: {this.Author.Id}) {this.PublishedAt} - {this.Title}";
  }
  public string Href => HrefFormat(this.Id);
  public static string HrefFormat(string v) => $"https://www.youtube.com/watch?v={v}";
}
