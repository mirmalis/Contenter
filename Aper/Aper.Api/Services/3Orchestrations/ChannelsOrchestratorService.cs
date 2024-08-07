using Aper.Api.Services._0Brokers.DateTimes;
using Aper.Api.Services._0Brokers.TruthBrokers;
using Aper.Api.Services._0Brokers.TruthBrokers.Models;
using Aper.Api.Services._2Processing;
using Aper.Models.Channels;

namespace Aper.Api.Services._3Orchestrations;

public partial class ChannelsOrchestratorService(
  IChannelProcessingService channels, 
  ITrueDataBroker api, 
  IDateTimeBroker dt
): IChannelsOrchestratorService
{
  IChannelProcessingService channels { get; } = channels;
  ITrueDataBroker api { get; } = api;
  DateTimeOffset now { get; } = dt.GetCurrentDateTime();
  //
  public async ValueTask<Channel?> GetChannel(string channelId)
  {
    var existing = await this.channels.GetOneById(channelId);
    bool isOld = true;
    if(existing != null && !isOld)
      return existing;
    var details = await api.GetChannelDetails(channelId);
    if(details == null)
      return null;
    var created = await this.channels.CreateOrUpdateOne(details.Merge(null, this.now));

    return created;
  }
}
