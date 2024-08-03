using Aper.Models.Playlists;
using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  private static void ConfigPlaylist(ModelBuilder mb)
  {
    mb.Entity<Playlist>(videos => {
      videos.ToTable("Playlist");
      videos.Property(item => item.CreatedDate).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
  }
}
