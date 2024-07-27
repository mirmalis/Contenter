using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  private static void ConfigChannels(ModelBuilder mb)
  {
    mb.Entity<Aper.Models.Channel>(channels => {
      channels.ToTable("Channel");
      channels.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
  }
}
