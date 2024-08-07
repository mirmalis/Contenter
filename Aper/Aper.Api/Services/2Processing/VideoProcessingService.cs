using Aper.Api.Services._1Foundations;
using Aper.Models.Videos;

namespace Aper.Api.Services._2Processing;

public partial class VideoProcessingService(IVideoService videoService):
  AbstractProcessingService<Video, string, IVideoService>(videoService),
  IVideoProcessingService
{
  public async ValueTask<IEnumerable<Video>> GetExistingVideosByPlaylistIdAsync(string playlistId)
  {
    return await this.service.GetVideoByPlaylistIdAsync(playlistId);
  }
}
