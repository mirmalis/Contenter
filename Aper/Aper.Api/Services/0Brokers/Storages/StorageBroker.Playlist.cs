using Microsoft.EntityFrameworkCore;
using Aper.Models.Playlists;

namespace Aper.Api.Services._0Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<Playlist> Playlists => this.Set<Playlist>();

  public IQueryable<Playlist> GetPlaylists() => this.SelectAll<Playlist>();
  public async ValueTask<Playlist?> ReadPlaylistByIdAsync(string id) => await this.SelectAsync<Playlist>(id);
  public async ValueTask<Playlist> InsertPlaylistAsync(Playlist playlist) => await this.InsertAsync(playlist);
  public async ValueTask<Playlist> UpdatePlaylistAsync(Playlist playlist) => await this.UpdateAsync(playlist);
  public async ValueTask<Playlist> DeletePlaylistAsync(Playlist playlist) => await this.DeleteAsync(playlist);
}
