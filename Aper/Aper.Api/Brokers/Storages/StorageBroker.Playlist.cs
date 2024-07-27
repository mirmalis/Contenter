using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<Aper.Models.Playlist> Playlists => this.Set<Aper.Models.Playlist>();
  public IQueryable<Aper.Models.Playlist> SelectAllPlaylists() => this.Playlists;
}
