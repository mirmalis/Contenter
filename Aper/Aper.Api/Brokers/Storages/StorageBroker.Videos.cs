using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aper.Api.Brokers.Storages;

public partial class StorageBroker
{
  public DbSet<Aper.Models.Video> Videos => this.Set<Aper.Models.Video>();
  public IQueryable<Aper.Models.Video> SelectAllVideos() => this.Videos;

  public async ValueTask<Aper.Models.Video> InsertVideoAsync(Aper.Models.Video video)
  {
    var broker = new StorageBroker(this.configuration);
    if(video.Channel != null)
    {
      var existingChannel = await broker.SelectChannelByIdAsync(video.Channel.Id);
      if(existingChannel != null)
      {
        video.ChannelId = video.Channel.Id;
        video.Channel = null!;
      }
    }
    EntityEntry<Aper.Models.Video> videoEntityEntry = await broker.Videos.AddAsync(entity: video);
    await broker.SaveChangesAsync();

    return videoEntityEntry.Entity;
  }
  public async ValueTask<Aper.Models.Video?> SelectVideoByIdAsync(string videoId)
  {
    var broker = new StorageBroker(configuration);
    broker.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    return await this.Videos.FindAsync(videoId);
  }

  public async ValueTask<Aper.Models.Video> UpdateVideoAsync(Aper.Models.Video video)
  {
    var broker = new StorageBroker(this.configuration);
    EntityEntry<Aper.Models.Video> videoEntityEntry = broker.Videos.Update(entity: video);
    await broker.SaveChangesAsync();

    return videoEntityEntry.Entity;
  }

  public async ValueTask<Aper.Models.Video> DeleteVideoAsync(Aper.Models.Video video)
  {
    var broker = new StorageBroker(this.configuration);
    EntityEntry<Aper.Models.Video> videoEntityEntry = broker.Videos.Remove(entity: video);
    await broker.SaveChangesAsync();

    return videoEntityEntry.Entity;
  }

}
