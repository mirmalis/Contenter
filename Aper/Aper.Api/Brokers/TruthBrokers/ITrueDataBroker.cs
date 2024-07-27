using Aper.Api.Brokers.YoutubeApiBrokers.Models;

namespace Aper.Api.Brokers.YoutubeApiBrokers;

public interface ITrueDataBroker
{
  Task<ChannelDetails?> GetChannelDetails(string? channelId, string? handle = null, string? username = null);
  Task<PlaylistDetails?> GetPlaylistDetails(string playlistId);
  Task<IEnumerable<PlaylistItemDetails>> Playlist_GetAllVideoIds(string playlistId, DateTime? until);
  Task<VideoDetails?> VideoDetails(string videoId);
}
