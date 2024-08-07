
namespace Aper.Api.Services._4Aggregators;

public interface IChannelAggregator
{
  Task<object?> GetChannel(string channelId);
}
