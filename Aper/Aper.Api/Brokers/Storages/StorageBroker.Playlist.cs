using Microsoft.EntityFrameworkCore;
using Aper.Models;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<Playlist> Playlists => this.Set<Playlist>();

  public IQueryable<Playlist> ReadPlaylists()
    => this.SelectAll<Playlist>();
  public async ValueTask<Playlist?> ReadPlaylistByIdAsync(string id)
    => await SelectAsync<Playlist>(id);
  public async ValueTask<Playlist> CreatePlaylistAsync(Playlist playlist)
    => await InsertAsync(playlist);
  public async ValueTask<Playlist> UpdatePlaylistAsync(Playlist playlist)
    => await this.UpdateAsync(playlist);
  public async ValueTask<Playlist> DeletePlaylistAsync(Playlist playlist)
    => await this.DeleteAsync(playlist);
}
