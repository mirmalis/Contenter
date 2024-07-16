using Contenter.Models.Configurations;

namespace Contenter.Brokers.Youtube;

public class AperYoutubeApiInteractor: IYoutubeApiInteractor
{
  #region Constructors
  public HttpClient httpClient { get; }
  public AperYoutubeApiInteractor(HttpClient httpClient, IConfiguration configuration)
  {
    this.httpClient = httpClient;
    var apiConfiguration =
        configuration.Get<LocalConfiguration>()?.ApiConfiguration ?? throw new Exception("Configuration exception");
    this.httpClient.BaseAddress = new System.Uri(apiConfiguration.Url);
  }
  #endregion
  public async Task<VideoModel?> GetVideoInfo(string identifier)
  {
    return await this.httpClient.GetFromJsonAsync<VideoModel>($"/YoutubeVideo?identifier={identifier}");
  }
}
