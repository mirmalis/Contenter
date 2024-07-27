using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<Aper.Models.PlaylistItem> PlaylistItems => this.Set<Aper.Models.PlaylistItem>();
  public IQueryable<Aper.Models.PlaylistItem> SelectAllPlaylistItems() => this.PlaylistItems;
}
