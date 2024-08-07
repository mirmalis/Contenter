using Aper.Models.Channels;

namespace Aper.Api.Services._3Orchestrations;

public interface IChannelsOrchestratorService
{
  ValueTask<Channel?> GetChannel(string channelId);
}
