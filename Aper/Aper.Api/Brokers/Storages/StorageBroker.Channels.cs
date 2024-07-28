using Microsoft.EntityFrameworkCore;
namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<Aper.Models.Channel> Channels
    => this.Set<Aper.Models.Channel>();

  public IQueryable<Aper.Models.Channel> ReadChannelsAll()
    => this.SelectAll<Aper.Models.Channel>();
  public async ValueTask<Aper.Models.Channel?> ReadChannelByIdAsync(string id)
    => await SelectAsync<Aper.Models.Channel>(id);
  public async ValueTask<Aper.Models.Channel> CreateChannelAsync(Aper.Models.Channel channel)
    => await InsertAsync(channel);
  public async ValueTask<Aper.Models.Channel> UpdateChannelAsync(Aper.Models.Channel channel)
    => await this.UpdateAsync(channel);
  public async ValueTask<Aper.Models.Channel> DeleteChannelAsync(Aper.Models.Channel channel)
    => await this.DeleteAsync(channel);
}
