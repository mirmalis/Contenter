using Aper.Models;

namespace Aper.Api.Brokers.Storages;

public partial interface IStorageBroker
{
  //Channels
  IQueryable<Channel> ReadChannels();
  ValueTask<Channel?> ReadChannelByIdAsync(string id);
  ValueTask<Channel> CreateChannelAsync(Channel channel);
  ValueTask<Channel> UpdateChannelAsync(Channel channel);
  ValueTask<Channel> DeleteChannelAsync(Channel channel);
  // Videos
  IQueryable<Video> ReadVideos();
  ValueTask<Video?> ReadVideoByIdAsync(string id);
  ValueTask<Video> CreateVideoAsync(Video video);
  ValueTask<Video> UpdateVideoAsync(Video video);
  ValueTask<Video> DeleteVideoAsync(Video video);
  // Playlist
  IQueryable<Playlist> ReadPlaylists();
  ValueTask<Playlist?> ReadPlaylistByIdAsync(string id);
  ValueTask<Playlist> CreatePlaylistAsync(Playlist playlist);
  ValueTask<Playlist> UpdatePlaylistAsync(Playlist playlist);
  ValueTask<Playlist> DeletePlaylistAsync(Playlist playlist);
}
