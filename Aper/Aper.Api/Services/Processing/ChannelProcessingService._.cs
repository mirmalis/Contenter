using Aper.Models.Channels;

namespace Aper.Api.Services.Processing;

public interface IChannelProcessingService
{
  ValueTask<Channel> UpsertChannelAsync(Channel Channel);
  ValueTask<Channel?> GetChannelByIdAsync(string id);
  ValueTask<Channel> AddChannelAsync(Channel Channel);
}
