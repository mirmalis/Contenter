using Contenter.Models.Configurations;
using Contenter.Models.Views;

namespace Contenter.Services.Views.Youtube;

public class YoutubeBroker: IYoutubeBroker
{
  #region Constructors
  public HttpClient httpClient { get; }
  public YoutubeBroker(HttpClient httpClient, IConfiguration configuration)
  {
    this.httpClient = httpClient;
    var apiConfiguration =
        configuration.Get<LocalConfiguration>()?.ApiConfiguration ?? throw new Exception("Configuration exception");
    this.httpClient.BaseAddress = new Uri(apiConfiguration.Url);
  }
  #endregion
  public async Task<YoutubeVideo?> GetVideoInfo(string identifier)
  {
    return await httpClient.GetFromJsonAsync<YoutubeVideo>($"/YoutubeVideo?identifier={identifier}");
  }
}
