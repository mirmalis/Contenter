using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  private static void ConfigPlaylistItems(ModelBuilder mb)
  {
    mb.Entity<Aper.Models.PlaylistItem>(videos => {
      videos.ToTable("PlaylistItems");
      videos.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
  }
}
