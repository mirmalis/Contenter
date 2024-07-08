namespace Contenter;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
public class Aper(HttpClient http)
{
  public HttpClient Http { get; } = http;
  public class ChannelIdentifier
  {
    public string Id { get; set; }
  }
  public class Video
  {
    public string Id { get; set; }
    public ChannelIdentifier Author { get; set; }
    public DateTime PublishedAt { get; set; }
    public string Title { get; set; }
    public override string ToString()
    {
      return $"Video id={this.Id} (Author: {this.Author.Id}) {this.PublishedAt} - {this.Title}";
    }
    public string Href => HrefFormat(this.Id);
    public static string HrefFormat(string v) => $"https://www.youtube.com/watch?v={v}";
  }
  public async Task<Video?> GetVideo(string identifier)
  {
    return await this.Http.GetFromJsonAsync<Video>($"/YoutubeVideo?identifier={identifier}");
  }
}
