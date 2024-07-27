using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<Aper.Models.Channel> Channels => this.Set<Aper.Models.Channel>();
  public IQueryable<Aper.Models.Channel> SelectAllChannels() => this.Channels;


  public async ValueTask<Aper.Models.Channel?> SelectChannelByIdAsync(string channelId)
  {
    var broker = new StorageBroker(configuration);
    broker.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    return await this.Channels.FindAsync(channelId);
  }
}
