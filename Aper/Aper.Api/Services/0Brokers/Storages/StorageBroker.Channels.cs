using Microsoft.EntityFrameworkCore;
using Aper.Models.Channels;
namespace Aper.Api.Services._0Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<Channel> Channels => this.Set<Channel>();

  public IQueryable<Channel> GetChannels() => this.SelectAll<Channel>();
  public async ValueTask<Channel?> ReadChannelByIdAsync(string id) => await SelectAsync<Channel>(id);
  public async ValueTask<Channel> InsertChannelAsync(Channel channel) => await InsertAsync(channel);
  public async ValueTask<IEnumerable<Channel>> InsertChannelsAsync(IEnumerable<Channel> channel) => await this.InsertManyNewAsync<Channel, string>(channel);
  public async ValueTask<Channel> UpdateChannelAsync(Channel channel) => await this.UpdateAsync(channel);
  public async ValueTask<Channel> DeleteChannelAsync(Channel channel) => await this.DeleteAsync(channel);
}
