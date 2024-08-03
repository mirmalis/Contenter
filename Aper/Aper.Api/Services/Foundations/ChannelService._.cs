using Aper.Models.Channels;

namespace Aper.Api.Services.Foundations;

public interface IChannelService
{
  ValueTask<Channel> AddChannelAsync(Channel video);
  ValueTask<Channel> ModifyChannelAsync(Channel video);
  IQueryable<Channel> RetrieveAllChannels();
  ValueTask<Channel?> RetrieveChannelByIdAsync(string id);
}
