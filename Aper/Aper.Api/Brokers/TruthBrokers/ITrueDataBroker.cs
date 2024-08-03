using Aper.Api.Brokers.TruthBrokers.Models;

namespace Aper.Api.Brokers.TruthBrokers;

public interface ITrueDataBroker
{
  // Channels
  Task<ChannelDetails?> GetChannelDetails(string? channelId, string? handle = null, string? username = null);
  // Videos
  Task<VideoDetails?> VideoDetails(string videoId);
  // Playlists
  Task<PlaylistDetails?> GetPlaylistDetails(string playlistId);
  // PlaylistItems
  Task<IEnumerable<PlaylistItemDetails>> GetPlaylistItemsByPlaylistId(string playlistId);
}
