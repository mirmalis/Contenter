using Aper.Api.Brokers.DateTimes;
using Aper.Api.Brokers.TruthBrokers;
using Aper.Api.Brokers.TruthBrokers.Models;
using Aper.Api.Services.Foundations;
using Aper.Api.Services.Processing;
using Aper.Models.Videos;

namespace Aper.Api.Services.Orchestrations;

public partial class VideoOrchestrationService: IVideoOrchestrationService
{

  #region Constructors
  public VideoOrchestrationService(IVideoProcessingService videoProcessingService, ITrueDataBroker api, IChannelProcessingService channelProcessingService, IDateTimeBroker dateTimeBroker)
  {
    this.videoProcessingService = videoProcessingService;
    this.api = api;
    this.channelProcessingService = channelProcessingService;
    this.dateTimeBroker = dateTimeBroker;
  }
  private IVideoProcessingService videoProcessingService { get; }
  private ITrueDataBroker api { get; }
  private IChannelProcessingService channelProcessingService { get; }
  private IDateTimeBroker dateTimeBroker { get; }
  #endregion
  public async ValueTask<Video?> GetVideo(string videoId)
  {
    var existing = await this.videoProcessingService.GetVideoByIdAsync(videoId);
    bool isOld = false;
    if(existing != null && !isOld)
    {
      return existing;
    }

    var details = await api.VideoDetails(videoId);
    if(details == null)
    {
      return null;
    }
    var now = this.dateTimeBroker.GetCurrentDateTime();
    var ch = await this.channelProcessingService.UpsertChannelAsync(details.Channel.Merge(null, now));
    var created = await this.videoProcessingService.AddVideoAsync
    (
      details.Merge(null, now)
    );
    return created;
  }
}
