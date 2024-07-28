using Aper.Api.Brokers.Storages;
using Aper.Api.Brokers.TruthBrokers;
using Aper.Api.Brokers.TruthBrokers.Models;

namespace Aper.Api.Services.Foundations.Playlists;

public class PlaylistService(IStorageBroker storageBroker, ITrueDataBroker truthBroker): IPlaylistService
{
  private IStorageBroker storageBroker { get; } = storageBroker;
  private ITrueDataBroker truthBroker { get; } = truthBroker;

  private async Task<PlaylistDetails?> Create(string id)
  {
    var details = await truthBroker.GetPlaylistDetails(id);
    if (details == null)
      return null;
    var now = DateTime.UtcNow.NoMS();
    var core = details.Merge(null, null, now);
    await storageBroker.CreatePlaylistAsync(core);

    return details;
  }
  private async Task<PlaylistDetails?> Update(string playlistId, Models.Playlist core)
  {
    if (core == null)
      throw new ArgumentNullException(nameof(core));

    var details = await truthBroker.GetPlaylistDetails(playlistId);
    if (details == null)
      return null;
    var now = DateTime.UtcNow.NoMS();
    core = details.Merge(core, null, now);
    await storageBroker.UpdatePlaylistAsync(core);

    return details;
  }

  public async Task<PlaylistDetails?> Get(string playlistId, bool cacheless = false)
  {
    var core = await this.storageBroker.ReadPlaylistByIdAsync(id: playlistId);
    if (!cacheless && core != null)
    {
      bool isUpToDate = false; // TODO
      if (isUpToDate)
      {
        throw new NotImplementedException();
      }
    }
    return core == null
      ? await Create(playlistId)
      : await Update(playlistId, core);
  }
}