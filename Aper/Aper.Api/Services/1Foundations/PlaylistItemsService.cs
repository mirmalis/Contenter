using Aper.Api.Services._0Brokers.DateTimes;
using Aper.Api.Services._0Brokers.Logging;
using Aper.Api.Services._0Brokers.Storages;
using Aper.Models.PlaylistItems;

namespace Aper.Api.Services._1Foundations;

public partial class PlaylistItemsService: 
  AbstractFoundryService<PlaylistItem, string>, 
  IPlaylistItemsService
{
  #region Constructors
  public PlaylistItemsService(IStorageBroker storageBroker, IDateTimeBroker dateTimeBroker, ILoggingBroker loggingBroker)
    : base(storageBroker, loggingBroker, dateTimeBroker)
  {
  }
  #endregion
  protected override async ValueTask<PlaylistItem> DoUpdate(PlaylistItem obj) => await this.db.UpdatePlaylistItemAsync(obj);
  protected override async ValueTask<PlaylistItem> DoInsert(PlaylistItem obj) => await this.db.InsertPlaylistItemAsync(obj);
  protected override async ValueTask<PlaylistItem?> DoSelect(string id) => await this.db.ReadPlaylistItemByIdAsync(id);
}
