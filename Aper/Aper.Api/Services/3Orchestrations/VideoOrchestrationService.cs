using Aper.Api.Services._0Brokers.DateTimes;
using Aper.Api.Services._0Brokers.TruthBrokers;
using Aper.Api.Services._0Brokers.TruthBrokers.Models;
using Aper.Api.Services._2Processing;
using Aper.Models.Videos;

namespace Aper.Api.Services._3Orchestrations;

public partial class VideoOrchestrationService: IVideoOrchestrationService
{

  #region Constructors
  public VideoOrchestrationService(IVideoProcessingService videoProcessingService, IPlaylistProcessingService playlistProcessingService, ITrueDataBroker api, IChannelProcessingService channelProcessingService, IDateTimeBroker dateTimeBroker)
  {
    this.videoProcessingService = videoProcessingService;
    this.playlistProcessingService = playlistProcessingService;
    this.api = api;
    this.channelProcessingService = channelProcessingService;
    this.dateTimeBroker = dateTimeBroker;
  }
  private IDateTimeBroker dateTimeBroker { get; }
  private IVideoProcessingService videoProcessingService { get; }
  private IPlaylistProcessingService playlistProcessingService { get; }
  private IChannelProcessingService channelProcessingService { get; }
  private ITrueDataBroker api { get; }
  #endregion

  public async ValueTask<Video?> GetVideo(string videoId)
  {
    var existing = await this.videoProcessingService.GetOneById(videoId);
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
    var ch = await this.channelProcessingService.CreateOrUpdateOne(details.Channel.Merge(null, now));
    var created = await this.videoProcessingService.CreateOrUpdateOne // TODO: Buvo create, galimai per daug metodas daro.
    (
      details.Merge(null, now)
    );
    return created;
  }

  public async ValueTask<IEnumerable<Video>> GetExistingVideosByPlaylistIdAsync(string playlistId)
  {
    var result = await this.videoProcessingService.GetExistingVideosByPlaylistIdAsync(playlistId);
    return result;
  }
}
