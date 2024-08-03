using Aper.Api.Services.Foundations;
using Aper.Models.Channels;

namespace Aper.Api.Services.Processing;

public partial class ChannelProcessingService: IChannelProcessingService
{
  #region Constructors
  private IChannelService channelService { get; }
  public ChannelProcessingService(IChannelService channelService)
  {
    this.channelService = channelService;
  }
  #endregion
  public async ValueTask<Channel> UpsertChannelAsync(Channel channel)
  {
    if (channel is null)
      throw new Exception();

    bool exists = this.channelService.RetrieveAllChannels().Any(item => item.Id == channel.Id);

    return exists
      ? await this.channelService.ModifyChannelAsync(channel)
      : await this.channelService.AddChannelAsync(channel)
      ;
  }

  public ValueTask<Channel?> GetChannelByIdAsync(string id)
  {
    throw new NotImplementedException();
  }

  public ValueTask<Channel> AddChannelAsync(Channel Channel)
  {
    throw new NotImplementedException();
  }
}
