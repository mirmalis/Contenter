using Aper.Models;

namespace Aper.Api.Brokers.Storages;

public partial interface IStorageBroker
{
  //Channels
  IQueryable<Channel> ReadChannelsAll();
  ValueTask<Channel?> ReadChannelByIdAsync(string channelId);
  ValueTask<Channel> CreateChannelAsync(Channel channel);
  ValueTask<Channel> UpdateChannelAsync(Channel channel);
  ValueTask<Channel> DeleteChannelAsync(Channel channel);
  // Videos
  IQueryable<Video> ReadVideosAll();
  ValueTask<Video?> ReadVideoByIdAsync(string videoId);
  ValueTask<Video> CreateVideoAsync(Video video);
  ValueTask<Video> UpdateVideoAsync(Video video);
  ValueTask<Video> DeleteVideoAsync(Video video);
}
