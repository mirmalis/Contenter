using Aper.Api.Services._1Foundations;
using Aper.Models.Channels;

namespace Aper.Api.Services._2Processing;

public partial class ChannelProcessingService(IChannelService channelService): 
  AbstractProcessingService<Channel, string, IChannelService>(channelService),
  IChannelProcessingService
{
}
