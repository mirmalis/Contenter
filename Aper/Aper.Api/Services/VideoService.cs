﻿using Aper.Api.Brokers.Storages;
using Aper.Api.Brokers.YoutubeApiBrokers;
using Aper.Api.Brokers.YoutubeApiBrokers.Models;
using Aper.Api.Controllers;
namespace Aper.Api.Services;

public interface IVideoService
{
  Task<VideoDetails?> Get(string videoId, bool cacheless = false);
}
public class VideoService(IStorageBroker storageBroker, ITrueDataBroker truthBroker): IVideoService
{
  private readonly IStorageBroker cache = storageBroker;
  private readonly ITrueDataBroker truthBroker = truthBroker;

  private async Task<VideoDetails?> Create(string videoId)
  {
    var details = await truthBroker.VideoDetails(videoId);
    if (details == null)
      return null;
    var now = DateTime.UtcNow.NoMS();
    var core = details.Merge(null, now);
    await this.cache.InsertVideoAsync(core);

    return details;
  }
  private async Task<VideoDetails?> Update(string videoId, Models.Video core)
  {
    if (core == null)
      throw new ArgumentNullException(nameof(core));

    var details = await truthBroker.VideoDetails(videoId);
    if (details == null)
      return null;
    var now = DateTime.UtcNow.NoMS();
    core = details.Merge(core, now);
    await this.cache.UpdateVideoAsync(core);

    return details;
  }
  public async Task<VideoDetails?> Get(string videoId, bool cacheless = false)
  {
var core = await this.cache.SelectVideoByIdAsync(videoId);
    if (!cacheless && core != null)
    {
      bool isUpToDate = false; // TODO
      if (isUpToDate)
      {
        throw new NotImplementedException();
      }
    }
    return core == null
      ? await Create(videoId)
      : await Update(videoId, core);
  }
}
