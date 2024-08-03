using Aper.Api.Services.Foundations;
using Aper.Models.Videos;

namespace Aper.Api.Services.Processing;

public partial class VideoProcessingService(IVideoService videoService): IVideoProcessingService
{
  public IVideoService VideoService { get; } = videoService;

  public async ValueTask<Video?> GetVideoByIdAsync(string videoId) => await this.VideoService.RetrieveVideoByIdAsync(videoId);
  public async ValueTask<Video> UpsertVideoAsync(Video video)
  {
    if(video is null)
      throw new Exception();

    bool exists = this.VideoService.RetrieveAllVideos().Any(item => item.Id == video.Id);

    return exists 
      ? await this.VideoService.ModifyVideoAsync(video)
      : await this.VideoService.AddVideoAsync(video)
      ;
  }
  public async ValueTask<Video> AddVideoAsync(Video video) => await this.VideoService.AddVideoAsync(video);
}
