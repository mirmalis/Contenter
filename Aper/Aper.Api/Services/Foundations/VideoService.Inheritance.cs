using Aper.Api.Brokers.DateTimes;
using Aper.Api.Brokers.Logging;
using Aper.Api.Brokers.Storages;
using Aper.Models.Videos;

namespace Aper.Api.Services.Foundations;

public partial class VideoService
{
  #region Constructors
  public VideoService(IStorageBroker storageBroker, ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker)
    : base(loggingBroker, dateTimeBroker)
  {
    this.storageBroker = storageBroker;
  }
  private readonly IStorageBroker storageBroker;
  #endregion

  protected override async ValueTask<Video?> DoSelect(string id) => await this.storageBroker.SelectVideoByIdAsync(id);
  protected override async ValueTask<Video> DoInsert(Video video) => await this.storageBroker.InsertVideoAsync(video);
  protected override async ValueTask<Video> DoUpdate(Video video) => await this.storageBroker.UpdateVideoAsync(video);
}
