using Aper.Api.Services._3Orchestrations;

namespace Aper.Api.Services._4Aggregators;

public class Aggregator(IPlaylistOrchestrationService playlists, IVideoOrchestrationService videos): IAggregator
{
  public IPlaylistOrchestrationService playlists { get; } = playlists;
  public IVideoOrchestrationService videos { get; } = videos;

  public async ValueTask<IEnumerable<object>> GetPlaylistsLatestVideos(string playlistId)
  {
    await this.playlists.EnsurePlaylistUpToDate(playlistId);
    var result = await this.videos.GetExistingVideosByPlaylistIdAsync(playlistId);
    return result.Select(video => new {
      video.PublishedAt,
      video.Id,
      video.Title,
      Channel = new {
        Id= video.ChannelId,
      },
      video.PrivacyStatus,
    });
  }
}
