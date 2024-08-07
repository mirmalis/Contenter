using Aper.Models.Channels;
using Aper.Models.Videos;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aper.Api.Services._0Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<Video> Videos => this.Set<Video>();
  public IQueryable<Video> GetVideos() => this.Videos;
  public async ValueTask<Video> InsertVideoAsync(Video video)
  {
    var broker = new StorageBroker(this.configuration);
    if (video.Channel != null)
    {
      var existingChannel = await broker.ReadChannelByIdAsync(video.Channel.Id); // TODO: pagalvot ar this nėra blogai, galimai broker reikia. Kai išsiaiškinsiu kodėl naują brokerį kuriam, nuspręsiu
      if (existingChannel != null)
      {
        video.ChannelId = video.Channel.Id;
        video.Channel = null!;
      }
    }
    EntityEntry<Video> videoEntityEntry = await broker.Videos.AddAsync(entity: video);
    await broker.SaveChangesAsync();

    return videoEntityEntry.Entity;
  }
  public async ValueTask<Video?> ReadVideoByIdAsync(string videoId)
  {
    var broker = new StorageBroker(configuration);
    broker.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    return await this.Videos.FindAsync(videoId);
  }
  public async ValueTask<Video> UpdateVideoAsync(Video video)
  {
    var broker = new StorageBroker(this.configuration);
    EntityEntry<Video> videoEntityEntry = broker.Videos.Update(entity: video);
    await broker.SaveChangesAsync();

    return videoEntityEntry.Entity;
  }
  public async ValueTask<Video> DeleteVideoAsync(Video video)
  {
    var broker = new StorageBroker(this.configuration);
    EntityEntry<Video> videoEntityEntry = broker.Videos.Remove(entity: video);
    await broker.SaveChangesAsync();

    return videoEntityEntry.Entity;
  }
  public async ValueTask<IEnumerable<Video>> CreateVideosAsync(IEnumerable<Video> videos)
  {
    return await this.InsertManyNewAsync<Aper.Models.Videos.Video, string>(videos);

  }
}
