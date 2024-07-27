using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  private static void ConfigChannelSnippet(ModelBuilder mb)
  {
    mb.Entity<Aper.Models.ChannelSnippet>(videos => {
      videos.ToTable("ChannelSnippets");
      videos.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
  }
}
