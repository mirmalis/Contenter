using Aper.Api.Services._3Orchestrations;

namespace Aper.Api.Services._4Aggregators;

public class VideoAggregator(
  IVideoOrchestrationService videoService
): IVideoAggregator
{
  IVideoOrchestrationService videoService { get; } = videoService;

  public async ValueTask<object?> GetVideo(string videoId)
  {
    var result = await this.videoService.GetVideo(videoId, existing => new {
      existing.PublishedAt,
      Channel = new {
        Id = existing.ChannelId,
        Title = existing.Channel.Title,
        Uploads = new {
          Id = existing.Channel.UploadsPlaylistId,
        },
      },
      existing.Id,
      existing.Title,
      Privacy = existing.PrivacyStatus == null ? null : new {
        Accessible = existing.PrivacyStatus.Value.HasFlag(Aper.Models.AccessStates._accessible),
        Listed = existing.PrivacyStatus.Value.HasFlag(Aper.Models.AccessStates._listed)
      },
      existing.Description,
    });
    return result;
  }
}
