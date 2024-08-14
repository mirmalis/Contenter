using Aper.Api.Services._2Processing;
using Aper.Models.Playlists;
using Aper.Api.Services._0Brokers.DateTimes;
using Aper.Api.Services._0Brokers.TruthBrokers;
using Aper.Api.Services._0Brokers.TruthBrokers.Models;

namespace Aper.Api.Services._3Orchestrations;

public partial class PlaylistOrchestrationService: IPlaylistOrchestrationService
{
  #region Constructors
  public PlaylistOrchestrationService(IVideoProcessingService videoProcessingService, IPlaylistProcessingService playlistProcessingService, IPlaylistItemsProcessingService playlistItemsProcessingService, IChannelProcessingService channelProcessingService, ITrueDataBroker api, IDateTimeBroker dt)
  {
    this.videoProcessingService = videoProcessingService;
    this.playlistProcessingService = playlistProcessingService;
    this.playlistItemsProcessingService = playlistItemsProcessingService;
    this.channelProcessingService = channelProcessingService;
    this.api = api;
    this.now = dt.GetCurrentDateTime();
  }
  private DateTimeOffset now;
  IChannelProcessingService channelProcessingService { get; }
  IVideoProcessingService videoProcessingService { get; }
  IPlaylistProcessingService playlistProcessingService { get; }
  IPlaylistItemsProcessingService playlistItemsProcessingService { get; }
  ITrueDataBroker api { get; }
  #endregion
  public async ValueTask<Playlist?> EnsurePlaylistExists(string playlistId)
  {
    var playlist = await this.playlistProcessingService.GetOneById(playlistId);
    if (playlist is not null)
      return playlist;
    var details = await this.api.GetPlaylistDetails(playlistId);
    if (details is null)
      return null;
    var core = details.Merge(null, null);
    var channelCore = details.Channel.Merge(null, now: this.now);
    var createdChannel = await this.channelProcessingService.CreateOrUpdateOne(channelCore);

    var result = await this.playlistProcessingService.CreateOrUpdateOne(core);
    return result;
  }
  public async ValueTask<Playlist?> EnsurePlaylistUpToDateUntil(string playlistId, DateTimeOffset until)
  {
    var playlist = await this.EnsurePlaylistExists(playlistId);
    if (playlist == null)
      return null; // bad playlistId

    var playlistItems = await this.api.GetPlaylistItemsByPlaylistIdUntil(playlistId, until);
    await this.write(playlistItems);

    return playlist;
  }
  public async ValueTask<Playlist?> EnsurePlaylistUpToDate(string playlistId)
  {
    var playlist = await this.EnsurePlaylistExists(playlistId);
    if (playlist == null)
      return null; // bad playlistId

    var playlistItems = await this.api.GetPlaylistItemsByPlaylistId(playlistId);
    await this.write(playlistItems);

    return playlist;
  }
  private async ValueTask write(IEnumerable<PlaylistItemDetails> playlistItems)
  {
    if(playlistItems == null || !playlistItems.Any())
      return;

    var videos = playlistItems.Select(item => item.Video.Merge(null, now));
    var channels = playlistItems.Select(item => item.Video.Channel.Merge(null, now));
    var inputs = playlistItems.Select(item => item.Merge(null, this.now));

    await this.channelProcessingService.CreateNonExsistant(channels);
    await this.videoProcessingService.CreateNonExsistant(videos);
    await this.playlistItemsProcessingService.CreateOrUpdateMany(inputs);
  }
}
