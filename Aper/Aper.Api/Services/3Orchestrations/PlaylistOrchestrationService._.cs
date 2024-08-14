using Aper.Models.Playlists;

namespace Aper.Api.Services._3Orchestrations;

public interface IPlaylistOrchestrationService
{
  ValueTask<Playlist?> EnsurePlaylistExists(string playlistId);
  ValueTask<Playlist?> EnsurePlaylistUpToDate(string playlistId);
  ValueTask<Playlist?> EnsurePlaylistUpToDateUntil(string playlistId, DateTimeOffset since);
}
