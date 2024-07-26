using Aper.Api.Brokers.Models;

using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace Aper.Api.Brokers;

public interface IYoutubeApiBroker
{
  Task<ChannelDetails?> GetChannelDetails(string? channelId, string? handle = null, string? username = null);
  Task<PlaylistDetails?> GetPlaylistDetails(string playlistId);
  Task<IEnumerable<PlaylistItemDetails>> Playlist_GetAllVideoIds(string playlistId, DateTime? until);
}
public class YoutubeApiBroker : IYoutubeApiBroker
{
  #region Constructors
  YouTubeService YoutubeService { get; }
  public YoutubeApiBroker(IConfiguration configuration) : base() {

    var apiKey= configuration["YoutubeApi:Key"];
    var name = configuration["YoutubeApi:Name"];
    this.YoutubeService = new YouTubeService(
      new BaseClientService.Initializer { 
        ApiKey = apiKey,
        ApplicationName = name
      }
    );
  }
  
  #endregion
  #region Channels
  public async Task<ChannelDetails?> GetChannelDetails(string? channelId, string? handle = null, string? username = null)
  {
    var response = await
      this.ChannelsResource_ListRequest(ChannelsResource_List_Parts.snippet | ChannelsResource_List_Parts.contentDetails, 1, channelId: channelId, handle: handle, username: username)
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
      Since = data.Snippet.PublishedAtRaw.ParseRawDateTime(),
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
      this.ChannelsResource_ListRequest(ChannelsResource_List_Parts.id, 5, handle: handle, username: username)
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

    ChannelsResource.ListRequest request = this.YoutubeService.Channels.List(parts.ToString());
    request.Id = channelId;
    request.ForHandle = handle;
    request.ForUsername = username;
    request.MaxResults = maxResults;

    return request;
  }
  #endregion
  #region Videos
  
  #endregion
  #region Playlists
  public async Task<PlaylistDetails?> GetPlaylistDetails(string playlistId)
  {
    var response = await this
      .Playlist_ListRequest(PlaylistsResource_List_Parts.snippet | PlaylistsResource_List_Parts.status | PlaylistsResource_List_Parts.contentDetails, 2, playlistId: playlistId)
      .ExecuteAsync();
    if (!response.Items.Any())
      return null;

    var data = response.Items.First();


    return new PlaylistDetails() {
      Id = data.Id,
      Since = data.Snippet.PublishedAtRaw.ParseRawDateTime(),
      Title = data.Snippet.Title,
      Description = data.Snippet.Description,
      Channel = new BasicChannelInfo() {
        Id = data.Snippet.ChannelId,
        Title = data.Snippet.ChannelTitle,
      },
      PrivacyStatus = data.Status.PrivacyStatus.ToPrivacyStatus(),
      CurrentItemsCount = data.ContentDetails.ItemCount,
    };
  }
  [Flags]
  public enum PlaylistsResource_List_Parts
  {
    None = 0,
    id = 1,
    status = 2,
    snippet = 4,
    contentDetails = 8,
    player = 16,
    localizations = 32,
  }
  private PlaylistsResource.ListRequest Playlist_ListRequest(PlaylistsResource_List_Parts parts, long? maxResult, string? playlistId)
  {
    var request = this.YoutubeService.Playlists.List(parts.ToString());
    request.MaxResults = maxResult;
    request.Id = playlistId;
    return request;
  }
  #endregion
  #region PlaylistItems
  public async Task<IEnumerable<PlaylistItemDetails>> Playlist_GetAllVideoIds(string playlistId, DateTime? until)
  {
    List<PlaylistItemDetails> result = [];
    var nextPageToken = "";
    while (nextPageToken != null)
    {
      var request = this.PlaylistItems_ListRequest(PlaylistItemsResource_List_Parts.contentDetails|PlaylistItemsResource_List_Parts.snippet|PlaylistItemsResource_List_Parts.status, 50, playlistId, nextPageToken);
      var response = await request.ExecuteAsync();
      nextPageToken = response.NextPageToken;
      if(!response.Items.Any())
        break;
      var newItems = response.Items
        .Select(item => 
          new PlaylistItemDetails() {
            Id = item.Id,
            PublishedAt = item.Snippet.PublishedAtRaw.ParseRawDateTime(),
            Position = item.Snippet.Position,
            Playlist = new BasicPlaylistInfo {
              Id = item.Snippet.PlaylistId,
            },
            Video = new BasicVideoInfo () {
              Id = item.ContentDetails.VideoId,
              Title = item.Snippet.Title,
              Description = item.Snippet.Description,
              PublishedAt = item.ContentDetails.VideoPublishedAtRaw.ParseRawDateTime(),
              PrivacyStatus = item.Status.PrivacyStatus.ToPrivacyStatus(),
              Channel = new BasicChannelInfo() {
                Id = item.Snippet.VideoOwnerChannelId,
                Title = item.Snippet.VideoOwnerChannelTitle,
              }
            }
          }
        );
      result.AddRange(newItems);
      if (until != null && newItems.Last().PublishedAt < until)
      {
        break;
      }
    }
    return result;
  }
  [Flags]
  private enum PlaylistItemsResource_List_Parts
  {
    None = 0,
    id = 1,
    status = 2,
    snippet = 4,
    contentDetails = 8,
  }
  private PlaylistItemsResource.ListRequest PlaylistItems_ListRequest(PlaylistItemsResource_List_Parts parts, long? maxResults, string? playlistId, string? pageToken = null)
  {
    var request = this.YoutubeService.PlaylistItems.List(parts.ToString());
    request.PlaylistId = playlistId;
    request.MaxResults = maxResults;
    request.PageToken = pageToken;
    return request;
  }
  #endregion

}
