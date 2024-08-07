using Aper.Models.Channels;

namespace Aper.Api.Services._2Processing;

public interface IChannelProcessingService: IAbstractProcessingService<Channel, string>
{
  ValueTask<Channel> CreateOrUpdateOne(Channel channel);
}
