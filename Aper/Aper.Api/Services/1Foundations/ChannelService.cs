using Aper.Api.Services._0Brokers.DateTimes;
using Aper.Api.Services._0Brokers.Logging;
using Aper.Api.Services._0Brokers.Storages;
using Aper.Models.Channels;
namespace Aper.Api.Services._1Foundations;

public partial class ChannelService:
  AbstractFoundryService<Channel, string>,
  IChannelService
{
  protected override Channel MergeForUpdating(Channel input, Channel existing)
  {
    existing.Title ??= input.Title;
    existing.Handle ??= input.Handle;
    existing.Country ??= input.Country;
    existing.UploadsPlaylistId ??= input.UploadsPlaylistId;
    existing.PublishedAt ??= input.PublishedAt;

    return base.MergeForUpdating(input, existing);
  }
  #region Constructors
  public ChannelService(IStorageBroker storageBroker, ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker) : base(storageBroker, loggingBroker, dateTimeBroker)
  {
  }
  #endregion
  public async ValueTask<Channel?> RetrieveChannelByIdAsync(string id) => await this.db.ReadChannelByIdAsync(id);
  protected override async ValueTask<Channel> DoUpdate(Channel channel) => await this.db.UpdateChannelAsync(channel);
  protected override async ValueTask<Channel> DoInsert(Channel channel) => await this.db.InsertChannelAsync(channel);
  protected override async ValueTask<Channel?> DoSelect(string id) => await this.db.ReadChannelByIdAsync(id);
}
