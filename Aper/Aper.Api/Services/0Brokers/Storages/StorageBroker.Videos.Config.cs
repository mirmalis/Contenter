using Aper.Models.Videos;
using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Services._0Brokers.Storages;

public partial class StorageBroker
{
  private static void ConfigVideos(ModelBuilder mb)
  {
    mb.Entity<Video>(videos => {
      videos.ToTable("Video");
      videos.Property(item => item.CreatedDate).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
  }
}
