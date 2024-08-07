using Aper.Models.Channels;

namespace Aper.Api.Services._1Foundations;

public interface IChannelService: IAbstractFoundationService<Channel, string>
{
  ValueTask<Channel?> RetrieveChannelByIdAsync(string id);
}
