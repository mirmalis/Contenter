using Aper.Models.Channels;
using Aper.Models.Videos;

namespace Aper.Api.Brokers.Storages;

public partial interface IStorageBroker
{

  // Channels
  IQueryable<Channel> ReadChannels();
  ValueTask<Channel?> ReadChannelByIdAsync(string id);
  ValueTask<Channel> CreateChannelAsync(Channel channel);
  ValueTask<IEnumerable<Channel>> CreateChannelsAsync(IEnumerable<Channel> channel);
  ValueTask<Channel> UpdateChannelAsync(Channel channel);
  ValueTask<Channel> DeleteChannelAsync(Channel channel);
  // Videos
  ValueTask<Video> InsertVideoAsync(Video video);
  IQueryable<Video> SelectAllVideos();
  ValueTask<Video?> SelectVideoByIdAsync(string videoId);
  ValueTask<Video> UpdateVideoAsync(Video video);
  //ValueTask<Video> DeleteVideoAsync(Video video);
  //// Playlist
  //IQueryable<Playlist> ReadPlaylists();
  //ValueTask<Playlist?> ReadPlaylistByIdAsync(string id);
  //ValueTask<Playlist> CreatePlaylistAsync(Playlist playlist);
  //ValueTask<Playlist> UpdatePlaylistAsync(Playlist playlist);
  //ValueTask<Playlist> DeletePlaylistAsync(Playlist playlist);
  //// PlaylistItems
  //IQueryable<PlaylistItem> ReadPlaylistItems();
  //ValueTask<PlaylistItem?> ReadPlaylistItemByIdAsync(string id);
  //ValueTask<PlaylistItem> CreatePlaylistItemAsync(PlaylistItem playlistItem);
  //ValueTask<IEnumerable<PlaylistItem>> CreatePlaylistItemsAsync(IEnumerable<PlaylistItem> playlistItems);
  //ValueTask<PlaylistItem> UpdatePlaylistItemAsync(PlaylistItem playlistItem);
  //ValueTask<PlaylistItem> DeletePlaylistItemAsync(PlaylistItem playlistItem);
}
