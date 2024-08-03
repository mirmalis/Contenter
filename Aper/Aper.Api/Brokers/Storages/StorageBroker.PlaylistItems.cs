using Aper.Models.PlaylistItems;
using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<PlaylistItem> PlaylistItems => this.Set<PlaylistItem>();

  public IQueryable<PlaylistItem> ReadPlaylistItems()
    => this.SelectAll<PlaylistItem>();
  public async ValueTask<PlaylistItem?> ReadPlaylistItemByIdAsync(string id)
    => await SelectAsync<PlaylistItem>(id);
  public async ValueTask<PlaylistItem> CreatePlaylistItemAsync(PlaylistItem playlistItem)
    => await InsertAsync(playlistItem);
  public async ValueTask<IEnumerable<PlaylistItem>> CreatePlaylistItemsAsync(IEnumerable<PlaylistItem> playlistItems)
    => await this.InsertManyNewAsync<PlaylistItem, string>(playlistItems);
  
  public async ValueTask<PlaylistItem> UpdatePlaylistItemAsync(PlaylistItem playlistItem)
    => await this.UpdateAsync(playlistItem);
  public async ValueTask<PlaylistItem> DeletePlaylistItemAsync(PlaylistItem playlistItem)
    => await this.DeleteAsync(playlistItem);
}
