using Aper.Models.Channels;
using Aper.Models.PlaylistItems;
using Aper.Models.Playlists;
using Aper.Models.Videos;

namespace Aper.Api.Services._0Brokers.Storages;

public partial interface IStorageBroker
{
  IQueryable<T> GetAll<T>() where T : class;
  ValueTask<T?> GetOne<T, TKey>(TKey id) where T : class, IIded<TKey>;

  // Channels
  IQueryable<Channel> GetChannels();
  ValueTask<Channel?> ReadChannelByIdAsync(string id);
  ValueTask<Channel> InsertChannelAsync(Channel channel);
  ValueTask<IEnumerable<Channel>> InsertChannelsAsync(IEnumerable<Channel> channel);
  ValueTask<Channel> UpdateChannelAsync(Channel channel);
  ValueTask<Channel> DeleteChannelAsync(Channel channel);
  // Videos
  IQueryable<Video> GetVideos();
  ValueTask<Video?> ReadVideoByIdAsync(string videoId);
  ValueTask<Video> InsertVideoAsync(Video video);
  ValueTask<Video> UpdateVideoAsync(Video video);
  //ValueTask<Video> DeleteVideoAsync(Video video);
  //// Playlist
  IQueryable<Playlist> GetPlaylists();
  ValueTask<Playlist?> ReadPlaylistByIdAsync(string id);
  ValueTask<Playlist> InsertPlaylistAsync(Playlist playlist);
  ValueTask<Playlist> UpdatePlaylistAsync(Playlist playlist);
  ValueTask<Playlist> DeletePlaylistAsync(Playlist playlist);
  //// PlaylistItems
  IQueryable<PlaylistItem> GetPlaylistItems();
  ValueTask<PlaylistItem?> ReadPlaylistItemByIdAsync(string id);
  ValueTask<PlaylistItem> InsertPlaylistItemAsync(PlaylistItem playlistItem);
  ValueTask<IEnumerable<PlaylistItem>> InsertPlaylistItemsAsync(IEnumerable<PlaylistItem> playlistItems);
  ValueTask<PlaylistItem> UpdatePlaylistItemAsync(PlaylistItem playlistItem);
  ValueTask<PlaylistItem> DeletePlaylistItemAsync(PlaylistItem playlistItem);
}
