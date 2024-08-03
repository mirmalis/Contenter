using Aper.Models.Channels;
using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  private static void ConfigChannels(ModelBuilder mb)
  {
    mb.Entity<Channel>(channels => {
      channels.ToTable("Channel");
      channels.Property(item => item.CreatedDate).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
  }
}
