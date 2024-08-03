using Aper.Models.Videos;

namespace Aper.Api.Services.Processing;

public interface IVideoProcessingService
{
  ValueTask<Video> UpsertVideoAsync(Video video);
  ValueTask<Video?> GetVideoByIdAsync(string videoId);
  ValueTask<Video> AddVideoAsync(Video video);
}
