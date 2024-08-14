using Aper.Api.Services._3Orchestrations;
using Aper.Models.Playlists;

namespace Aper.Api.Services._4Aggregators;

public class TopPlaylistFunctions: ITopPlaylistFunctions
{
  #region Constructors
  public IPlaylistOrchestrationService playlists { get; }
  public IVideoOrchestrationService videos { get; }
  public TopPlaylistFunctions(IPlaylistOrchestrationService playlists, IVideoOrchestrationService videos)
  {
    this.playlists = playlists;
    this.videos = videos;
  }
  #endregion
  


  public async ValueTask<IEnumerable<object>> UpdatePlaylistUntil(string playlistId, DateTimeOffset since)
  {
    await this.playlists.EnsurePlaylistUpToDateUntil(playlistId, since);
    var result = await this.videos.GetExistingVideosByPlaylistIdAsync(playlistId);
    return result.Select(Selectors.videoSelector);
  }
  public async ValueTask<IEnumerable<object>> GetPlaylistsLatestVideos(string playlistId)
  {
    await this.playlists.EnsurePlaylistUpToDate(playlistId);
    var result = await this.videos.GetExistingVideosByPlaylistIdAsync(playlistId);
    return result.Select(Selectors.videoSelector);
  }

  public async ValueTask<Playlist?> EnsureExists(string playlistId)
  {
    if(playlistId is null)
      throw new ArgumentNullException(nameof(playlistId));
    var existing = await this.playlists.EnsurePlaylistExists(playlistId);
    return existing;
  }
}
