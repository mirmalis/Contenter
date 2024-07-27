using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  private static void ConfigVideos(ModelBuilder mb)
  {
    mb.Entity<Aper.Models.Video>(videos => {
      videos.ToTable("Video");
      videos.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
  }
}
