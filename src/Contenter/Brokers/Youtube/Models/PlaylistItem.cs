namespace Contenter.Brokers.Youtube.Models;

public class PlaylistItem
{
  public string Id { get; set; }
  public string Title { get; set; }
  public string Href => $"https://www.youtube.com/watch?v={this.Id}";
  public DateTimeOffset PublishedAt { get; set; }
  public ChannelId Channel { get; set; }
  public PrivacyStruct Privacy { get; set; }

  public record struct ChannelId
  {
    public string Id { get; set; }
  }
  public record struct PrivacyStruct
  {
    public bool Accessible { get; set; }
    public bool Listed { get; set; }
  }
}
