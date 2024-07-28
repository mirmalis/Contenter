using Microsoft.EntityFrameworkCore;
using Aper.Models;
namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<Channel> Channels
    => this.Set<Channel>();

  public IQueryable<Channel> ReadChannels()
    => this.SelectAll<Channel>();
  public async ValueTask<Channel?> ReadChannelByIdAsync(string id)
    => await SelectAsync<Channel>(id);
  public async ValueTask<Channel> CreateChannelAsync(Channel channel)
    => await InsertAsync(channel);
  public async ValueTask<Channel> UpdateChannelAsync(Channel channel)
    => await this.UpdateAsync(channel);
  public async ValueTask<Channel> DeleteChannelAsync(Channel channel)
    => await this.DeleteAsync(channel);
}
