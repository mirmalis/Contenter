using Aper.Api.Brokers.Storages;
using Aper.Api.Brokers.TruthBrokers;
using Aper.Api.Brokers.TruthBrokers.Models;
namespace Aper.Api.Services.Foundations.Channels;

public class ChannelService(
  IStorageBroker storageBroker,
  ITrueDataBroker truthBroker
): IChannelService
{
  private IStorageBroker storageBroker { get; } = storageBroker;
  private ITrueDataBroker truthBroker { get; } = truthBroker;


  private async Task<ChannelDetails?> Create(string id)
  {
    var details = await truthBroker.GetChannelDetails(id);
    if (details == null)
      return null;
    var now = DateTime.UtcNow.NoMS();
    var core = details.Merge(null, now);
    await storageBroker.CreateChannelAsync(core);

    return details;
  }
  private async Task<ChannelDetails?> Update(string channelId, Models.Channel core)
  {
    if (core == null)
      throw new ArgumentNullException(nameof(core));

    var details = await truthBroker.GetChannelDetails(channelId);
    if (details == null)
      return null;
    var now = DateTime.UtcNow.NoMS();
    core = details.Merge(core, now);
    await storageBroker.UpdateChannelAsync(core);

    return details;
  }

  public async Task<ChannelDetails?> Get(string channelId, bool cacheless = false)
  {
    var core = await this.storageBroker.ReadChannelByIdAsync(id:channelId);
    if (!cacheless && core != null)
    {
      bool isUpToDate = false; // TODO
      if (isUpToDate)
      {
        throw new NotImplementedException();
      }
    }
    return core == null
      ? await Create(channelId)
      : await Update(channelId, core);
  }
}
