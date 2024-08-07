using Aper.Api.Services._3Orchestrations;

namespace Aper.Api.Services._4Aggregators;

public class ChannelAggregator(
   IChannelsOrchestratorService channels
): IChannelAggregator
{
  public IChannelsOrchestratorService Channels { get; } = channels;

  public async Task<object?> GetChannel(string channelId)
  {
    var existing = await this.Channels.GetChannel(channelId);
    if(existing is null)
      return null;

    return new {
      existing.Id,
      existing.UploadsPlaylistId,
      existing.Title,
      existing.Handle,
      existing.PublishedAt,
      existing.UpdatedDate,
    };
  }
}
