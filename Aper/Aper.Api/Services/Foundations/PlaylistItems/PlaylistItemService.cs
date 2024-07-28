using Aper.Api.Brokers.Storages;
using Aper.Api.Brokers.TruthBrokers;

namespace Aper.Api.Services.Foundations.PlaylistItems;

public class PlaylistItemService(IStorageBroker storageBroker, ITrueDataBroker truthBroker): IPlaylistItemService
{
  private IStorageBroker StorageBroker { get; } = storageBroker;
  private ITrueDataBroker TruthBroker { get; } = truthBroker;

}
