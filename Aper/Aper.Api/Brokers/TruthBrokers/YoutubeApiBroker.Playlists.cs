using Aper.Api.Brokers.TruthBrokers.Models;
using Aper.Api.Brokers.TruthBrokers.Models;

using Google.Apis.YouTube.v3;

namespace Aper.Api.Brokers.TruthBrokers;

public partial class YoutubeApiBroker
{
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
    var request = this.Playlists.List(parts.ToString());
    request.MaxResults = maxResult;
    request.Id = playlistId;
    return request;
  }
  public async Task<PlaylistDetails?> GetPlaylistDetails(string playlistId)
  {
    var response = await
      Playlist_ListRequest(PlaylistsResource_List_Parts.snippet | PlaylistsResource_List_Parts.status | PlaylistsResource_List_Parts.contentDetails, 2, playlistId: playlistId)
      .ExecuteAsync();
    if (!response.Items.Any())
      return null;

    var data = response.Items.First();


    return new PlaylistDetails() {
      Id = data.Id,
      PublishedAt = data.Snippet.PublishedAtRaw.ParseRawDateTime(),
      Title = data.Snippet.Title,
      Description = data.Snippet.Description,
      Channel = new BasicChannelInfo() {
        Id = data.Snippet.ChannelId,
        Title = data.Snippet.ChannelTitle,
      },
      PrivacyStatus = AsPrivacyStatus(data.Status.PrivacyStatus),
      CurrentItemsCount = data.ContentDetails.ItemCount,
    };
  }
  
}
