using Aper.Api.Services._0Brokers.TruthBrokers.Models;
using Google.Apis.YouTube.v3;

namespace Aper.Api.Services._0Brokers.TruthBrokers;

public partial class YoutubeApiBroker
{
  #region Privates
  private enum List_parts
  {
    None = 0,
    id = 1,
    status = 2,
    snippet = 4,
    statistics = 8,
    contentDetails = 16,
    fileDetails = 32,
    liveStreamingDetails = 64,
    localizations = 128,
    player = 256,
    processingDetails = 512,
    recordingDetails = 1024,
    suggestions = 2048,
    topicDetails = 4096,
  }
  private VideosResource.ListRequest Videos_ListRequest(List_parts parts, long? maxResults, string videoId)
  {
    if (parts == List_parts.None)
      throw new Exception($"{nameof(parts)}=={parts}");
    var request = this.Videos.List(parts.ToString());
    request.MaxResults = maxResults;
    request.Id = videoId;
    return request;
  }
  #endregion
  public async Task<VideoDetails?> VideoDetails(string videoId)
  {
    var response = await Videos_ListRequest(List_parts.snippet, 1, videoId)
      .ExecuteAsync();
    if (response.Items.Count == 0)
      return null;
    if (response.Items.Count > 1)
      throw new Exception("Unexpected number of details");

    var details = response.Items.First();
    return new VideoDetails() {
      Id = details.Id,
      PublishedAt = details.Snippet.PublishedAtRaw.ParseRawDateTime(),
      Title = details.Snippet.Title,
      Description = details.Snippet.Description,
      Channel = new BasicChannelInfo() {
        Id = details.Snippet.ChannelId,
        Title = details.Snippet.ChannelTitle,
      }
    };
  }
}
