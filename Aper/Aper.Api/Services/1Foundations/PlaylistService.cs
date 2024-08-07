using Aper.Api.Services._0Brokers.DateTimes;
using Aper.Api.Services._0Brokers.Logging;
using Aper.Api.Services._0Brokers.Storages;
using Aper.Models.Playlists;

namespace Aper.Api.Services._1Foundations;

public partial class PlaylistService: AbstractFoundryService<Playlist, string>, IPlaylistService
{
  #region Constructors
  public PlaylistService(ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker, IStorageBroker storageBroker) : 
    base(storageBroker, loggingBroker, dateTimeBroker)
  {
  }
  #endregion
  protected override async ValueTask<Playlist?> DoSelect(string id) => await this.GetOneById(id);
  protected override async ValueTask<Playlist> DoInsert(Playlist playlist) => await this.CreateOne(playlist);
  protected override async ValueTask<Playlist> DoUpdate(Playlist playlist) => await this.UpdateOne(playlist);

  
}
