using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  private static void ConfigPlaylist(ModelBuilder mb)
  {
    mb.Entity<Aper.Models.Playlist>(videos => {
      videos.ToTable("Playlist");
      videos.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
  }
}
