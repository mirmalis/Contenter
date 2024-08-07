using Aper.Api.Services._0Brokers.TruthBrokers.Models;
using Google.Apis.YouTube.v3;

namespace Aper.Api.Services._0Brokers.TruthBrokers;

public partial class YoutubeApiBroker
{
  public async Task<ChannelDetails?> GetChannelDetails(string? channelId, string? handle = null, string? username = null)
  {
    var response = await
      ChannelsResource_ListRequest(ChannelsResource_List_Parts.snippet | ChannelsResource_List_Parts.contentDetails, 1, channelId: channelId, handle: handle, username: username)
      .ExecuteAsync();
    if (!response.Items.Any())
    {
      return null;
    }
    if (response.Items.Count > 1)
    {
      throw new NotImplementedException();
    }
    var data = response.Items.First();
    return new ChannelDetails() {
      Id = data.Id,
      Handle = data.Snippet.CustomUrl,
      Title = data.Snippet.Title,
      Description = data.Snippet.Description,
      PublishedAt = data.Snippet.PublishedAtRaw.ParseRawDateTime(),
      Country = data.Snippet.Country,
      UploadsPlaylist = data.ContentDetails.RelatedPlaylists.Uploads,
      FavoritesPlaylist = data.ContentDetails.RelatedPlaylists.Favorites,
      WatchLaterPlaylist = data.ContentDetails.RelatedPlaylists.WatchLater,
      LikedPlaylist = data.ContentDetails.RelatedPlaylists.Likes,
    };
  }
  public async Task<string?> GetChannelId(string? handle = null, string? username = null)
  {
    var response = await
      ChannelsResource_ListRequest(ChannelsResource_List_Parts.id, 5, handle: handle, username: username)
      .ExecuteAsync();
    if (response.Items != null && response.Items.Count == 1)
    {
      return response.Items.First().Id;
    }
    return null;
  }
  [Flags]
  private enum ChannelsResource_List_Parts
  {
    None = 0,
    id = 1,
    status = 2,
    snippet = 4,
    statistics = 8,
    contentDetails = 16,
    topicDetails = 32,
    brandingSettings = 64,
    contentOwnerDetails = 128,
    localizations = 256,
    auditDetails = 512,
  }
  private ChannelsResource.ListRequest ChannelsResource_ListRequest(ChannelsResource_List_Parts parts, long maxResults, string? channelId = null, string? handle = null, string? username = null)
  {
    if (parts == ChannelsResource_List_Parts.None)
      throw new Exception("Atleast one part is required by youtube.");
    if (channelId == null && handle == null && username == null)
      throw new ArgumentNullException($"Provide atleast one identifier of channel ({nameof(channelId)}, {nameof(handle)}, {nameof(username)})");

    ChannelsResource.ListRequest request = this.Channels.List(parts.ToString());
    request.Id = channelId;
    request.ForHandle = handle;
    request.ForUsername = username;
    request.MaxResults = maxResults;

    return request;
  }
}
