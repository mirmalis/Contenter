using Aper.Api.Brokers.TruthBrokers.Models;
using Aper.Api.Controllers.Models;

using Google.Apis.YouTube.v3;

namespace Aper.Api.Brokers.TruthBrokers;

public partial class YoutubeApiBroker
{
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
    var request = this.PlaylistItems.List(parts.ToString());
    request.PlaylistId = playlistId;
    request.MaxResults = maxResults;
    request.PageToken = pageToken;
    return request;
  }
  public async Task<IEnumerable<PlaylistItemDetails>> GetPlaylistItemsByPlaylistId(string playlistId)
  {
    List<PlaylistItemDetails> result = [];
    var nextPageToken = "";
    while (nextPageToken != null)
    {
      var request = PlaylistItems_ListRequest(PlaylistItemsResource_List_Parts.contentDetails | PlaylistItemsResource_List_Parts.snippet | PlaylistItemsResource_List_Parts.status, 50, playlistId, nextPageToken);
      var response = await request.ExecuteAsync();
      nextPageToken = response.NextPageToken;
      if (!response.Items.Any())
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
            Channel = new () {
              Id = item.Snippet.ChannelId,
              Title = item.Snippet.ChannelTitle,
              
            },
            Video = new BasicVideoInfo() {
              Id = item.ContentDetails.VideoId,
              Title = item.Snippet.Title,
              Description = item.Snippet.Description,
              PublishedAt = item.ContentDetails.VideoPublishedAtRaw.ParseRawDateTime(),
              PrivacyStatus = AsPrivacyStatus(item.Status.PrivacyStatus),
              Channel = new BasicChannelInfo() {
                Id = item.Snippet.VideoOwnerChannelId,
                Title = item.Snippet.VideoOwnerChannelTitle,
              }
            }
          }
        );
      result.AddRange(newItems);
    }
    return result;
  }
  
}
