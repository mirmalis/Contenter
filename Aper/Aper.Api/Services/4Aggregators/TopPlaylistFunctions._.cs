
using Aper.Models.Playlists;

namespace Aper.Api.Services._4Aggregators;

public interface ITopPlaylistFunctions
{
  ValueTask<Playlist?> EnsureExists(string id);
  ValueTask<IEnumerable<object>?> GetPlaylistsLatestVideos(string playlistId);
  //ValueTask<IEnumerable<object>> UpdatePlaylistUntil(string playlistId, DateTimeOffset since);
}
