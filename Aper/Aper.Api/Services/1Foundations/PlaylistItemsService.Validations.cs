using Aper.Models.PlaylistItems;

namespace Aper.Api.Services._1Foundations;

public partial class PlaylistItemsService
{
  protected override TException ValidateInput_Common<TException>(TException x, PlaylistItem input)
  => x;
  protected override TException ValidateInput_CreateSpecific<TException>(TException x, PlaylistItem input)
  => x;
  protected override TException ValidateInput_ModifySpecific<TException>(TException x, PlaylistItem input)
  => x;
  protected override TException Validate_AgainstStorageObject<TException>(TException x, PlaylistItem input, PlaylistItem storage)
  => x;

  
}
