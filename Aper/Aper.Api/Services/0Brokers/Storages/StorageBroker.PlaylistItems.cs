using Aper.Models.PlaylistItems;

using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Services._0Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<PlaylistItem> PlaylistItems => this.Set<PlaylistItem>();

  public IQueryable<PlaylistItem> GetPlaylistItems()
    => this.SelectAll<PlaylistItem>();
  public async ValueTask<PlaylistItem?> ReadPlaylistItemByIdAsync(string id)
    => await SelectAsync<PlaylistItem>(id);
  public async ValueTask<PlaylistItem> InsertPlaylistItemAsync(PlaylistItem playlistItem)
    => await InsertAsync(playlistItem);
  public async ValueTask<IEnumerable<PlaylistItem>> InsertPlaylistItemsAsync(IEnumerable<PlaylistItem> playlistItems)
    => await this.InsertManyNewAsync<PlaylistItem, string>(playlistItems);
  public async ValueTask<PlaylistItem> UpdatePlaylistItemAsync(PlaylistItem playlistItem)
    => await this.UpdateAsync(playlistItem);
  public async ValueTask<PlaylistItem> DeletePlaylistItemAsync(PlaylistItem playlistItem)
    => await this.DeleteAsync(playlistItem);
}
