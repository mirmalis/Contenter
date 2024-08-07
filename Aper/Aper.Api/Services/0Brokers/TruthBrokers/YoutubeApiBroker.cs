using Aper.Api.Services._0Brokers.TruthBrokers;
using Aper.Api.Services._0Brokers.TruthBrokers.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace Aper.Api.Services._0Brokers.TruthBrokers;

public partial class YoutubeApiBroker: YouTubeService, ITrueDataBroker
{
  private static PrivacyStatuses AsPrivacyStatus(string statusName)
  {
    return statusName switch {
      "public" => PrivacyStatuses._public,
      "private" => PrivacyStatuses._private,
      "unlisted" => PrivacyStatuses._unlisted,
      _ => throw new NotImplementedException()
    };
  }

  private readonly IConfiguration _configuration;
  public YoutubeApiBroker(IConfiguration configuration) : base(
      new BaseClientService.Initializer {
        ApiKey = GetApiKey(configuration),
        ApplicationName = GetApplicationName(configuration)
      }
  )
    {
    this._configuration = configuration;
  }
  private static string GetApiKey(IConfiguration configuration)
  {
    var apiKey = configuration["YoutubeDataApiKey"];
    if (string.IsNullOrWhiteSpace(apiKey))
    {
      throw new InvalidOperationException("API key is not configured.");
    }
    return apiKey;
  }

  private static string GetApplicationName(IConfiguration configuration)
  {
    var applicationName = configuration["YoutubeDataApiApplicationName"];
    if (string.IsNullOrWhiteSpace(applicationName))
    {
      throw new InvalidOperationException("Application name is not configured.");
    }
    return applicationName;
  }
}
