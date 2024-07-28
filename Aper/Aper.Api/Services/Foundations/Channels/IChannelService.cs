using Aper.Api.Brokers.TruthBrokers.Models;

namespace Aper.Api.Services.Foundations.Channels;

public interface IChannelService
{
  Task<ChannelDetails?> Get(string channelId, bool cacheless = false);
}
