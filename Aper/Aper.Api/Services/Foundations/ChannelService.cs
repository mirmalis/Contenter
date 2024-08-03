using Aper.Api.Brokers.DateTimes;
using Aper.Api.Brokers.Logging;
using Aper.Api.Brokers.Storages;
using Aper.Models.Channels;
namespace Aper.Api.Services.Foundations;

public partial class ChannelService: AbstractFoundryService<Channel, string>, IChannelService
{

  #region Constructors
  private IStorageBroker storageBroker { get; }
  public ChannelService(IStorageBroker storageBroker, ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker) : base(loggingBroker, dateTimeBroker)
  {
    this.storageBroker = storageBroker;
  }
  #endregion

  public IQueryable<Channel> RetrieveAllChannels() => this.storageBroker.ReadChannels();
  public async ValueTask<Channel?> RetrieveChannelByIdAsync(string id) => await this.storageBroker.ReadChannelByIdAsync(id);
  public async ValueTask<Channel> AddChannelAsync(Channel video) => await this.standardAddAsync(video);
  public async ValueTask<Channel> ModifyChannelAsync(Channel video) => await this.standardModifyAsync(video);

  protected override async ValueTask<Channel> DoUpdate(Channel obj) => await this.storageBroker.UpdateChannelAsync(obj);
  protected override async ValueTask<Channel> DoInsert(Channel obj) => await this.storageBroker.CreateChannelAsync(obj);
  protected override async ValueTask<Channel?> DoSelect(string id) => await this.storageBroker.ReadChannelByIdAsync(id);
}
