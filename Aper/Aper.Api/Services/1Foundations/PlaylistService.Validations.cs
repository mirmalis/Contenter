using Aper.Models.Playlists;

namespace Aper.Api.Services._1Foundations;

public partial class PlaylistService
{
  protected override TException ValidateInput_Common<TException>(TException x, Playlist input)
    => x;
  protected override TException ValidateInput_CreateSpecific<TException>(TException x, Playlist input)
    => x;
  protected override TException ValidateInput_ModifySpecific<TException>(TException x, Playlist input)
    => x;
  protected override TException Validate_AgainstStorageObject<TException>(TException x, Playlist input, Playlist storage)
    => x;
}
