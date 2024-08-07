using Aper.Models.Videos;

namespace Aper.Api.Services._3Orchestrations;

public interface IVideoOrchestrationService
{
  ValueTask<Video?> GetVideo(string videoId);
  ValueTask<IEnumerable<Video>> GetExistingVideosByPlaylistIdAsync(string playlistId);
}
