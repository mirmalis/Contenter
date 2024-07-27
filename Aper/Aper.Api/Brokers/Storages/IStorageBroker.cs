namespace Aper.Api.Brokers.Storages;

public partial interface IStorageBroker
{
  //Channels
  ValueTask<Aper.Models.Channel?> SelectChannelByIdAsync(string channelId);
  // Videos
  ValueTask<Aper.Models.Video> InsertVideoAsync(Aper.Models.Video video);
  IQueryable<Aper.Models.Video> SelectAllVideos();
  ValueTask<Aper.Models.Video?> SelectVideoByIdAsync(string videoId);
  ValueTask<Aper.Models.Video> UpdateVideoAsync(Aper.Models.Video video);
  ValueTask<Aper.Models.Video> DeleteVideoAsync(Aper.Models.Video video);
}
