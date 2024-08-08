using Aper.Models.Videos;

namespace Aper.Api.Services._3Orchestrations;

public interface IVideoOrchestrationService
{
  ValueTask<TOut?> GetVideo<TOut>(string videoId, System.Linq.Expressions.Expression<Func<Video, TOut>> selector);
  ValueTask<IEnumerable<Video>> GetExistingVideosByPlaylistIdAsync(string playlistId);
}
