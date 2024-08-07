using Aper.Models.PlaylistItems;
using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Services._0Brokers.Storages;

public partial class StorageBroker
{
  private static void ConfigPlaylistItems(ModelBuilder mb)
  {
    mb.Entity<PlaylistItem>(videos => {
      videos.ToTable("PlaylistItems");
      videos.Property(item => item.CreatedDate).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
  }
}
