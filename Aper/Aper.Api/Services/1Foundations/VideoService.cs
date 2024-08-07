using Aper.Api.Services._0Brokers.DateTimes;
using Aper.Api.Services._0Brokers.Logging;
using Aper.Api.Services._0Brokers.Storages;
using Aper.Models.Videos;

using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Services._1Foundations;

public partial class VideoService:
  AbstractFoundryService<Video, string>,
  IVideoService
{
  protected override Video MergeForUpdating(Video input, Video existing)
  {
    input.Title ??= existing.Title;
    input.Description ??= existing.Description;
    input.PrivacyStatus ??= existing.PrivacyStatus;

    return base.MergeForUpdating(input, existing);
  }
  protected override async ValueTask<Video?> DoSelect(string id) => await this.db.ReadVideoByIdAsync(id);
  protected override async ValueTask<Video> DoInsert(Video video) => await this.db.InsertVideoAsync(video);
  protected override async ValueTask<Video> DoUpdate(Video video) => await this.db.UpdateVideoAsync(video);
  #region Constructors
  public VideoService(IStorageBroker storageBroker, ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker)
    : base(storageBroker, loggingBroker, dateTimeBroker)
  {
  }

  #endregion
  public IQueryable<Video> GetAllVideos() => this.db.GetVideos();
  public async ValueTask<IEnumerable<Video>> GetVideoByPlaylistIdAsync(string playlistId)
  {
    var result = await this.GetAllVideos()
      .Where(video => video.PlaylistAssignments.Any(item => item.PlaylistId == playlistId))
      .ToListAsync();
    return result;
  }
  public async ValueTask<Video?> GetVideoByIdAsync(string id) => await this.db.ReadVideoByIdAsync(id);
  public async ValueTask<Video> CreateVideo(Video video) => await this.standardAddAsync(video);
  public async ValueTask<Video> UpdateVideo(Video video) => await this.standardModifyAsync(video);

  public async ValueTask<IEnumerable<string>> GetExistingIds(IEnumerable<string> videoIds)
  {
    var result = await this.db.GetVideos()
      .Where(item => videoIds.Contains(item.Id))
      .Select(item => item.Id)
      .ToListAsync();
    return result;
  }

  public async ValueTask<IEnumerable<Video>> UpdateVideos(IEnumerable<Video> videos)
  {
    var list = new List<Video>();
    foreach (var video in videos)
    {

      var result = await this.UpdateVideo(video);
      list.Add(result);
    }
    return list;
  }
  public async ValueTask<IEnumerable<Video>> CreateVideos(IEnumerable<Video> videos)
  {
    var list = new List<Video>();
    foreach (var video in videos)
    {
      var result = await this.CreateVideo(video);
      list.Add(result);
    }
    return list;
  }
}
