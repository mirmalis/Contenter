using Aper.Models.Channels;

namespace Aper.Api.Services._1Foundations;

public partial class ChannelService
{
  protected override TException ValidateInput_Common<TException>(TException x, Channel input)
  {
    return x
      .AddInvalid(
        InvalidIf.InvalidId(input.Id, nameof(Channel.Id)),
        InvalidIf.IsDefault(input.Title, nameof(Channel.Title))
      )
    ;
  }

  protected override TException ValidateInput_CreateSpecific<TException>(TException x, Channel input)
  {
    return x
    ;
  }

  protected override TException ValidateInput_ModifySpecific<TException>(TException x, Channel input)
  {
    return x
    ;
  }

  protected override TException Validate_AgainstStorageObject<TException>(TException x, Channel input, Channel storage)
  {
    return x
    ;
  }
}
