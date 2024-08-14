
namespace Aper.Api.Services._4Aggregators;

public interface ITopChannelFunctions
{
  ValueTask<IEnumerable<object>> GetChannelsLatestVideos(string channelId);
}
